// FolderPathAttributeDrawer.cs
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
    /// A property drawer for FolderPathAttribute
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(FolderPathAttribute))]
    public class FolderPathAttributeDrawer : PropertyDrawer
    {
        private static readonly string SInvalidTypeMessage = L10n.Tr("Use Range with float or int.");

        private const float ButtonWidth = 20f;
        private const float Padding = 4f;
        private readonly GUIStyle m_folderButtonStyle;
        private readonly int m_assetsStringLength;

        public FolderPathAttributeDrawer()
        {
            m_folderButtonStyle = new GUIStyle(EditorStyles.iconButton)
            {
                fixedWidth = ButtonWidth
            };
            m_assetsStringLength = EditorGUIUtility.TrTextContent("Assets").text.Length;
        }

        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property,
                                   GUIContent label)
        {
            FolderPathAttribute attr = attribute as FolderPathAttribute;
            if (attr == null) return;

            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, SInvalidTypeMessage);
                return;
            }

            string path = property.stringValue;
            position.width -= ButtonWidth + Padding;
            EditorGUI.PropertyField(position, property, label);
            position.x += position.width + Padding;
            position.width = ButtonWidth;
            if (!GUI.Button(position, EditorGUIUtility.FindTexture("Project"), m_folderButtonStyle)) return;
            OnFolderButtonClick(property, path, attr);
            property.serializedObject.ApplyModifiedProperties();
        }

        /// <inheritdoc />
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            FolderPathAttribute attr = attribute as FolderPathAttribute;
            if (attr == null) return null;

            if (property.propertyType != SerializedPropertyType.String)
            {
                return new Label(SInvalidTypeMessage) { name = "unity-invalid-type-label" };
            }

            TextField propertyField = new TextField(property.displayName)
            {
                name = "unity-text-field",
                value = property.stringValue,
                multiline = true,
                style =
                {
                    whiteSpace = WhiteSpace.Normal,
                    flexGrow = 1f,
                    flexShrink = 1f
                }
            };
            propertyField.BindProperty(property);
            propertyField.RegisterValueChangedCallback(evt =>
            {
                property.stringValue = evt.newValue;
                property.serializedObject.ApplyModifiedProperties();
            });

            Button button = new Button(() =>
            {
                propertyField.value = OnFolderButtonClick(property, property.stringValue, attr);
            })
            {
                style =
                {
                    backgroundImage = EditorGUIUtility.FindTexture("Project"),
                    unityBackgroundScaleMode = ScaleMode.ScaleToFit,
                    width = ButtonWidth,
                    height = ButtonWidth
                }
            };

            //return this.CreatePropertyGUIContainer(new VisualElement[] { propertyField, button });
            VisualElement container = new VisualElement()
            {
                name = "unity-folder-path-container",
                style =
                {
                    flexDirection = FlexDirection.Row,
                    flexGrow = 1f,
                    flexShrink = 1f
                },
            };
            container.Add(propertyField);
            container.Add(button);
            return container;
        }

        #endregion

        private string OnFolderButtonClick(SerializedProperty property, string path, FolderPathAttribute attr)
        {
            path = EditorUtility.OpenFolderPanel("Select folder",
                                                 (attr.pathRelativeToProject)
                                                     ? ToAbsolutePath(path)
                                                     : path, string.Empty);
            if (string.IsNullOrEmpty(path))
            {
                return property.stringValue;
            }

            if (!attr.pathRelativeToProject)
            {
                property.stringValue = path;
                //Debug.Log($"{property.displayName} set to {path}");
                return property.stringValue;
            }

            property.stringValue = ToRelativePath(path);
            //Debug.Log($"{property.displayName} set to {property.stringValue}, relative to project {path}");

            return property.stringValue;
        }

        private string ToAbsolutePath(string relativePath)
        {
            return Application.dataPath.Substring(0, Application.dataPath.Length - m_assetsStringLength) + relativePath;
        }

        private string ToRelativePath(string absolutePath)
        {
            return absolutePath.Substring(Application.dataPath.Length - m_assetsStringLength);
        }
    }
}