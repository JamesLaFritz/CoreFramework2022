// RequiredReferencePropertyDrawer.cs
// 07-22-2022
// James LaFritz

using CoreFramework.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes

{
    /// <summary>
    /// A property drawer for RequiredReferenceAttribute
    /// <a href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html">UnityEditor.PropertyDrawer</a>
    /// </summary>
    [CustomPropertyDrawer(typeof(RequiredReferenceAttribute))]
    public class RequiredReferencePropertyDrawer : PropertyDrawer
    {
        private static bool IsNull(SerializedProperty property)
        {
            return property.propertyType == SerializedPropertyType.ObjectReference &&
                   property.objectReferenceValue == null;
        }

        private static bool IsFromMonoBehaviourOrScriptableObject(Object target)
        {
            return target != null && target is MonoBehaviour or ScriptableObject;
        }

        #region Overrides of PropertyDrawer

        /// <inheritdoc/>
        /// <summary>
        /// <a href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.OnGUI.html">PropertyDrawer.OnGUI</a>
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property,
                                   GUIContent label)
        {
            Object target = property.serializedObject.targetObject;
            if (!IsFromMonoBehaviourOrScriptableObject(target) || !IsNull(property))
            {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            GUI.color = Color.red;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.color = Color.white;

            Texture warningIcon = EditorGUIUtility.FindTexture("console.warnicon.sml");

            Rect warningRect = position;
            warningRect.xMin = position.xMax - warningIcon.width;
            warningRect.x -= 20.0f;
            warningRect.height = warningIcon.height;

            GUI.DrawTexture(warningRect, warningIcon, ScaleMode.ScaleToFit, true, 1.0f);
        }

        /// <inheritdoc/>
        /// <summary>
        /// <a href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.CreatePropertyGUI.html">PropertyDrawer.CreatePropertyGUI</a>
        /// </summary>
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            Object target = property.serializedObject.targetObject;
            VisualElement propertyFieldContainer = new VisualElement()
            {
                name = "required-reference-property-container",
                style =
                {
                    flexDirection = FlexDirection.Row,
                    flexGrow = 1,
                    flexShrink = 1
                }
            };
            PropertyField propertyField = new PropertyField(property, property.displayName)
            {
                name = "unity-property-field"
            };
            propertyFieldContainer.Add(propertyField);

            StyleSheet style = Resources.Load("RequiredReferenceStyleSheet") as StyleSheet;
            Texture warningIconTexture = EditorGUIUtility.IconContent("console.warnicon.sml").image;
            Image warningIcon = new Image
            {
                image = warningIconTexture,
                scaleMode = ScaleMode.ScaleToFit,
                style =
                {
                    width = warningIconTexture.width,
                    height = warningIconTexture.height
                },
                name = "warning-icon"
            };

            if (IsFromMonoBehaviourOrScriptableObject(target) && IsNull(property))
            {
                if (!propertyFieldContainer.Contains(warningIcon))
                    propertyFieldContainer.Add(warningIcon);
                if (!propertyFieldContainer.styleSheets.Contains(style))
                    propertyFieldContainer.styleSheets.Add(style);
            }

            return propertyFieldContainer;
        }

        #endregion
    }
}