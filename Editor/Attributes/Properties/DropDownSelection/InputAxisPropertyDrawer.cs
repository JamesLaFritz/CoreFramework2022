// InputAxisPropertyDrawer.cs
// 07-20-2022
// James LaFritz

using System.Collections.Generic;
using System.Linq;
using CoreFramework.Attributes.Properties.DropDownSelection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes.Properties.DropDownSelection
{
    /// <summary>
    /// A custom property drawer for the <see cref="InputAxisAttribute"/>.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(InputAxisAttribute))]
    public class InputAxisPropertyDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage =
            L10n.Tr($"{nameof(InputAxisAttribute)} supports only string fields");

        #region Overrides of PropertyDrawer

        /// <summary>
        /// Ons the gui using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="property">The property</param>
        /// <param name="label">The label</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null) return;

            if (property.propertyType != SerializedPropertyType.String)
            {
                label.text = SInvalidTypeMessage;
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            string[] axes = GetInputAxis();

            using EditorGUI.PropertyScope propertyScope = new EditorGUI.PropertyScope(position, label, property);
            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            int index = GetIndex(property.stringValue, axes);

            // Draw the popup box with the current selected index
            int newIndex = EditorGUI.Popup(position, label?.text, index, axes);

            // Adjust the actual string value of the property based on the selection
            string newValue = newIndex > 0 ? axes[newIndex] : string.Empty;

            if (property.stringValue?.Equals(newValue, System.StringComparison.Ordinal) == false)
            {
                property.stringValue = newValue;
            }

            if (changeCheck.changed)
            {
                property.serializedObject?.ApplyModifiedProperties();
            }
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
                return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };

            string[] axes = GetInputAxis();

            PopupField<string> popupField =
                new PopupField<string>(property.displayName, axes!.ToList(), GetIndex(property.stringValue, axes))
                {
                    name = "unity-popup-field"
                };

            popupField.RegisterValueChangedCallback((evt) =>
            {
                if (evt.newValue == evt.previousValue) return;
                property.stringValue = evt.newValue;
                property.serializedObject?.ApplyModifiedProperties();
            });

            // return this.CreatePropertyGUIContainer(popupField);
            return popupField;
        }

        #endregion

        /// <summary>
        /// Gets the input axis
        /// </summary>
        /// <returns>The string array</returns>
        private static string[] GetInputAxis()
        {
            #if !ENABLE_LEGACY_INPUT_MANAGER
            return new[] { "ENABLE_LEGACY_INPUT_MANAGER" };
            #endif

            Object inputManagerAsset =
                AssetDatabase.LoadAssetAtPath("ProjectSettings/InputManager.asset", typeof(object));
            SerializedObject inputManager = new SerializedObject(inputManagerAsset);

            HashSet<string> axesSet = new HashSet<string> { "(None)" };

            SerializedProperty axesProperty = inputManager.FindProperty("m_Axes");
            if (axesProperty == null || axesProperty.arraySize == 0)
            {
                Debug.LogError("No Axes Defined");
                return axesSet.ToArray();
            }

            for (int i = 0; i < axesProperty.arraySize; i++)
            {
                axesSet.Add(axesProperty.GetArrayElementAtIndex(i)?.FindPropertyRelative("m_Name")?.stringValue);
            }

            return axesSet.ToArray();
        }

        /// <summary>
        /// Gets the index using the specified property string
        /// </summary>
        /// <param name="propertyString">The property string</param>
        /// <param name="axes">The axes</param>
        /// <returns>The index</returns>
        private static int GetIndex(string propertyString, string[] axes)
        {
            int index = 0;
            // check if there is an entry that matches the entry and get the index
            // we skip index 0 as that is a special custom case
            for (int i = 1; i < axes.Length; i++)
            {
                if (axes[i] == null) continue;
                if (!axes[i].Equals(propertyString, System.StringComparison.Ordinal)) continue;
                index = i;
                break;
            }

            return index;
        }
    }
}