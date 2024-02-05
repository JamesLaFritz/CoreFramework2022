// SceneAttributePropertyDrawer.cs
// 07-20-2022
// James LaFritz

using System;
using System.Linq;
using System.Text.RegularExpressions;
using CoreFramework.Attributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// A custom property drawer for the  <see cref="CoreFramework.Attributes.SceneAttribute"/>.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneAttributePropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Gets the value of the any scene in build settings
        /// </summary>
        public static bool AnySceneInBuildSettings => GetScenes()?.Length > 0;

        private static readonly string SInvalidTypeMessage =
            L10n.Tr($"{nameof(SceneAttribute)} supports only string and int fields");

        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null) return;

            if (property.propertyType is not (SerializedPropertyType.String or SerializedPropertyType.Integer))
            {
                label.text = SInvalidTypeMessage;
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            if (!AnySceneInBuildSettings)
            {
                EditorGUI.HelpBox(
                    position,
                    "No scenes in the build settings, Please ensure that you add your scenes to File->Build Settings->",
                    MessageType.Error);
                return;
            }

            var scenes = GetScenes();
            var sceneOptions = GetSceneOptions(scenes);

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                using (var changeCheck = new EditorGUI.ChangeCheckScope())
                {
                    switch (property.propertyType)
                    {
                        case SerializedPropertyType.String:
                            DrawPropertyForString(position, property, label, scenes, sceneOptions);
                            break;
                        case SerializedPropertyType.Integer:
                            DrawPropertyForInt(position, property, label, sceneOptions);
                            break;
                    }

                    if (changeCheck.changed)
                    {
                        property.serializedObject?.ApplyModifiedProperties();
                    }
                }
            }
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property == null) return new Label("Property is null") { name = "unity-invalid-type-label" };

            if (property.propertyType is not (SerializedPropertyType.String or SerializedPropertyType.Integer))
                return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };

            var scenes = GetScenes() ?? new[] { "" };
            var scenesList = scenes!.ToList();

            PopupField<string> popupField;

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                popupField =
                    new PopupField<string>(property.displayName, scenesList, property.intValue);

                popupField.RegisterValueChangedCallback((evt) =>
                {
                    if (evt.newValue == evt.previousValue) return;
                    property.intValue = scenesList.IndexOf(evt.newValue);
                    property.serializedObject?.ApplyModifiedProperties();
                });

                //return this.CreatePropertyGUIContainer(popupField);
                return popupField;
            }

            popupField =
                new PopupField<string>(property.displayName, scenesList, scenesList.IndexOf(property.stringValue));

            popupField.RegisterValueChangedCallback((evt) =>
            {
                if (evt.newValue == evt.previousValue) return;
                property.stringValue = evt.newValue;

                property.serializedObject?.ApplyModifiedProperties();
            });

            //return this.CreatePropertyGUIContainer(popupField);
            return popupField;
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!AnySceneInBuildSettings) return EditorGUIUtility.singleLineHeight * 2;
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        #endregion

        /// <summary>
        /// Gets the scenes
        /// </summary>
        /// <returns>The string array</returns>
        public static string[] GetScenes()
        {
            return (from scene in EditorBuildSettings.scenes
                    where scene.enabled
                    select scene.path).ToArray();
        }

        /// <summary>
        /// Gets the scene options using the specified scenes
        /// </summary>
        /// <param name="scenes">The scenes</param>
        /// <returns>The string array</returns>
        public static string[] GetSceneOptions(string[] scenes)
        {
            return (from scene in scenes
                    select Regex.Match(scene ?? string.Empty,
                                       @".+\/(.+).unity").Groups[1].Value).ToArray();
        }

        /// <summary>
        /// Draws the property for string using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="property">The property</param>
        /// <param name="label">The label</param>
        /// <param name="scenes">The scenes</param>
        /// <param name="sceneOptions">The scene options</param>
        private static void DrawPropertyForString(Rect rect, SerializedProperty property, GUIContent label,
                                                  string[] scenes, string[] sceneOptions)
        {
            if (property == null) return;
            if (scenes == null) return;

            var index = Mathf.Clamp(Array.IndexOf(scenes, property.stringValue), 0, scenes.Length - 1);
            var newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, sceneOptions);
            var newScene = scenes[newIndex];

            if (property.stringValue?.Equals(newScene, StringComparison.Ordinal) == false)
            {
                property.stringValue = scenes[newIndex];
            }
        }

        /// <summary>
        /// Draws the property for int using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="property">The property</param>
        /// <param name="label">The label</param>
        /// <param name="sceneOptions">The scene options</param>
        private static void DrawPropertyForInt(Rect rect, SerializedProperty property, GUIContent label,
                                               string[] sceneOptions)
        {
            if (property == null) return;

            var index = property.intValue;
            var newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, sceneOptions);

            if (property.intValue != newIndex)
            {
                property.intValue = newIndex;
            }
        }
    }
}