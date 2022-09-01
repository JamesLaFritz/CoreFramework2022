// ShowIfBoolPropertyDrawer.cs
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
    /// A property drawer for ShowIfBoolAttribute
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(ShowIfBoolAttribute))]
    public class ShowIfBoolPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// The errormessage
        /// </summary>
        private string _errorMessage;

        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property,
                                   GUIContent label)
        {
            ShowIfBoolAttribute attr = attribute as ShowIfBoolAttribute;
            if (attr == null) return; 
            SerializedProperty showIfProp = PropertyDrawerHelper.FindProperty(property, attr.BoolName, out _errorMessage);
            if (showIfProp == null)
            {
                EditorGUI.LabelField(position, label.text, _errorMessage);
                return;
            }

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                if (PropertyDrawerHelper.ShouldShow(showIfProp.boolValue, attr.Show))
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }

            EditorGUI.indentLevel = indent;
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            ShowIfBoolAttribute attr = attribute as ShowIfBoolAttribute;
            if (attr == null) return new VisualElement();

            SerializedProperty showIfProp = PropertyDrawerHelper.FindProperty(property, attr.BoolName, out _errorMessage);

            if (showIfProp == null)
            {
                Label propertyLabel = new Label(property.displayName) { name = property.displayName + "Label" };
                Label label = new Label(_errorMessage);
                propertyLabel.Add(label);

                return propertyLabel;
            }

            PropertyField field = new PropertyField(property, property.displayName) { name = property.displayName };

            PropertyDrawerHelper.ShouldShow(showIfProp.boolValue, attr.Show);

            return field;
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfBoolAttribute attr = attribute as ShowIfBoolAttribute;
            if (attr == null) return base.GetPropertyHeight(property, label);
            SerializedProperty showIfProp = PropertyDrawerHelper.FindProperty(property, attr.BoolName, out _errorMessage);
            if (showIfProp == null) return base.GetPropertyHeight(property, label);
            if ((showIfProp.boolValue && attr.Show) ||
                (!showIfProp.boolValue && !attr.Show))
                return EditorGUI.GetPropertyHeight(property, label, true);
            return -EditorGUIUtility.standardVerticalSpacing;
        }

        #endregion
    }
}