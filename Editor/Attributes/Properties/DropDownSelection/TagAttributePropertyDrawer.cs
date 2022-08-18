// TagAttributePropertyDrawer.cs
// 07-20-2022
// James LaFritz

using CoreFramework.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// A custom property drawer for the <see cref="CoreFramework.Attributes.TagAttribute"/>.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagAttributePropertyDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage =
            L10n.Tr($"{nameof(InputAxisAttribute)} supports only string fields");

        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null) return;

            if (property.propertyType != SerializedPropertyType.String)
            {
                label.text = SInvalidTypeMessage;
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            using EditorGUI.PropertyScope scope = new EditorGUI.PropertyScope(position, label, property);
            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
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

            TagField tagField = new TagField(property.displayName, property.stringValue)
            {
                name = "unity-tag-field"
            };
            tagField.RegisterValueChangedCallback((evt) =>
            {
                if (evt.newValue == evt.previousValue) return;
                property.stringValue = evt.newValue;
                property.serializedObject?.ApplyModifiedProperties();
            });

            //return this.CreatePropertyGUIContainer(tagField);
            return tagField;
        }

        #endregion
    }
}