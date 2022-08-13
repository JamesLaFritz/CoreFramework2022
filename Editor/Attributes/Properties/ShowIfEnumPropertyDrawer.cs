// ShowIfEnumPropertyDrawer.cs
// 07-21-2022
// James LaFritz

using CoreFramework.Attributes.Properties;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes.Properties
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
            SerializedProperty showIfProp =
                PropertyDrawerHelper.FindProperty(property, attr.enumName, out _errorMessage);
            if (showIfProp == null)
            {
                EditorGUI.LabelField(position, label.text, _errorMessage);
            }

            PropertyDrawerHelper.LoadAttributes(this, label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                if (PropertyDrawerHelper.ShouldShow(showIfProp.enumValueIndex == attr.enumIndex, attr.show))
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }

            EditorGUI.indentLevel = indent;
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            ShowIfEnumValueAttribute attr = attribute as ShowIfEnumValueAttribute;
            SerializedProperty showIfProp =
                PropertyDrawerHelper.FindProperty(property, attr.enumName, out _errorMessage);
            VisualElement root = new VisualElement();

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

            if (PropertyDrawerHelper.ShouldShow(showIfProp.enumValueIndex == attr.enumIndex, attr.show))
                root.Add(new PropertyField(property, property.displayName));

            return root;
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfEnumValueAttribute attr = attribute as ShowIfEnumValueAttribute;
            SerializedProperty showIfProp =
                PropertyDrawerHelper.FindProperty(property, attr.enumName, out _errorMessage);
            if (showIfProp == null) return base.GetPropertyHeight(property, label);
            if (PropertyDrawerHelper.ShouldShow(showIfProp.enumValueIndex == attr.enumIndex, attr.show))
                return EditorGUI.GetPropertyHeight(property, label, true);
            return -EditorGUIUtility.standardVerticalSpacing;
        }

        #endregion
    }
}