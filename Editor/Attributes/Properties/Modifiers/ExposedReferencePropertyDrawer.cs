using CoreFramework.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// A property drawer for the <see cref="CoreFramework.Attributes.ExposedReferenceAttribute"/>
    /// Inherits from<a href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html">UnityEditor.PropertyDrawer</a>
    /// </summary>
    [CustomPropertyDrawer(typeof(ExposedReferenceAttribute))]
    public class ExposedReferencePropertyDrawer : PropertyDrawer
    {
        private Editor _editor;
        
        #region Property Drawer Overrides

        /// <summary>
        /// Override this method to make your own IMGUI based GUI for the property.
        /// <a href="https://docs.unity3d.com/2021.3/Documentation/ScriptReference/PropertyDrawer.OnGUI.html">UnityEditor.PropertyDrawer.OnGUI</a>
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label, true);

            if (property.objectReferenceValue != null)
                property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none);


            if (!property.isExpanded) return;

            EditorGUI.indentLevel++;

            if (!_editor)
                _editor = Editor.CreateEditor(property.objectReferenceValue);
            _editor.OnInspectorGUI();

            EditorGUI.indentLevel--;
        }

        /// <summary>
        /// Override this method to make your own UIElements based GUI for the property.
        /// <a href="https://docs.unity3d.com/2021.3/Documentation/ScriptReference/PropertyDrawer.CreatePropertyGUI.html">UnityEditor.PropertyDrawer.CreatePropertyGUI</a>
        /// </summary>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <returns>VisualElement The element containing the custom GUI. </returns>
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