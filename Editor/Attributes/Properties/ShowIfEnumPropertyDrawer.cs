// ShowIfEnumPropertyDrawer.cs
// 07-21-2022
// James LaFritz

using CoreFramework.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// A property drawer for ShowIfEnumValueAttribute
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(ShowIfEnumValueAttribute))]
    public class ShowIfEnumPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// The errormessage
        /// </summary>
        private string _errorMessage;

        #region Property Drawer Overrides

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property,
                                   GUIContent label)
        {
            ShowIfEnumValueAttribute attr = attribute as ShowIfEnumValueAttribute;
            if (attr == null) return;
            SerializedProperty showIfProp =
                PropertyDrawerHelper.FindProperty(property, attr.EnumName, out _errorMessage);
            if (showIfProp == null)
            {
                EditorGUI.LabelField(position, label.text, _errorMessage);
                return;
            }

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                if (PropertyDrawerHelper.ShouldShow(showIfProp.enumValueIndex == attr.EnumIndex, attr.Show))
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }

            EditorGUI.indentLevel = indent;
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (attribute is not ShowIfEnumValueAttribute attr) return new Label("ShowIfEnumValueAttribute not found.");
            var showIfProp =
                property.FindSerializedProperty(attr.EnumName, out _errorMessage);
            
            // Create a new VisualElement that will serve as the root of your property GUI.
            var container = new VisualElement();

            if (showIfProp == null)
            {
                Label propertyLabel = new Label(property.displayName) { name = property.displayName + "Label" };
                Label label = new Label(_errorMessage)
                {
                    name = property.displayName + "Error"
                };
                propertyLabel.SetEnabled(false);
                propertyLabel.Add(label);

                return propertyLabel;
            }

            if (PropertyDrawerHelper.ShouldShow(showIfProp.enumValueIndex == attr.EnumIndex, attr.Show))
                root.Add(new PropertyField(property, property.displayName));

            // Set the initial visibility
            UpdateVisibility(showIfProp);

            container.Add(propertyField);

            return container;

            // A callback that updates the visibility of the property field
            void UpdateVisibility(SerializedProperty enumProperty)
            {
                var shouldBeVisible = property.ShouldShow(enumProperty.enumValueIndex == attr.EnumIndex, attr.Show);
                container.visible = shouldBeVisible;
            }
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfEnumValueAttribute attr = attribute as ShowIfEnumValueAttribute;
            if (attr == null) return base.GetPropertyHeight(property, label);
            var showIfProp =
                property.FindSerializedProperty(attr.EnumName, out _errorMessage);
            if (showIfProp == null) return base.GetPropertyHeight(property, label);
            if (property.ShouldShow(showIfProp.enumValueIndex == attr.EnumIndex, attr.Show))
                return EditorGUI.GetPropertyHeight(property, label, true);
            return -EditorGUIUtility.standardVerticalSpacing;
        }

        #endregion
    }
}