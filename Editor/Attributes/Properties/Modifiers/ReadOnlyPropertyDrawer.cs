// ReadOnlyPropertyDrawer.cs
// 07-20-2022
// James LaFritz

using CoreFramework.Attributes.Properties.Modifiers;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes.Properties.Modifiers
{
    /// <summary>
    /// A property drawer for the <see cref="ReadOnlyAttribute"/>
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        #region Property Drawer Overrides

        /// <inheritdoc href="https://docs.unity3d.com/2021.3/Documentation/ScriptReference/PropertyDrawer.OnGUI.html"/>
        public override void OnGUI(Rect position, SerializedProperty property,
                                   GUIContent label)
        {
            PropertyDrawerHelper.LoadAttributes(this, label);

            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }

        /// <inheritdoc href="https://docs.unity3d.com/2021.3/Documentation/ScriptReference/PropertyDrawer.CreatePropertyGUI.html"/>
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            PropertyField propertyField = new PropertyField(property, property.displayName)
            {
                name = "unity-read-only-property-field"
            };
            propertyField.SetEnabled(false);
            //return this.CreatePropertyGUIContainer(propertyField);
            return propertyField;
        }

        #endregion
    }
}