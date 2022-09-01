using CoreFramework.ScriptableObjectArchitecture;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.ScriptableObjectArchitecture.PropertyDrawers
{
    /// <summary>
    /// The scene info property drawer class
    /// </summary>
    /// <seealso cref="PropertyDrawer"/>
    [CustomPropertyDrawer(typeof(SceneInfo))]
    public class SceneInfoPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// The scene preview title
        /// </summary>
        private const string ScenePreviewTitle = "Preview (Read-Only)";
        /// <summary>
        /// The scene name property
        /// </summary>
        private const string SceneNameProperty = "_sceneName";
        /// <summary>
        /// The scene index property
        /// </summary>
        private const string SceneIndexProperty = "_sceneIndex";
        /// <summary>
        /// The scene enabled property
        /// </summary>
        private const string SceneEnabledProperty = "_isSceneEnabled";
        /// <summary>
        /// The field count
        /// </summary>
        private const int FieldCount = 5;

        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
             SerializedProperty sceneNameProperty = property.FindPropertyRelative(SceneNameProperty);
            SerializedProperty sceneIndexProperty = property.FindPropertyRelative(SceneIndexProperty);
            SerializedProperty enabledProperty = property.FindPropertyRelative(SceneEnabledProperty);

            using EditorGUI.PropertyScope propertyScope = new EditorGUI.PropertyScope(position,
                new GUIContent(property.displayName), property);
            using EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope();

            // Draw Object Selector for SceneAssets
            Rect sceneAssetRect = new Rect
            {
                position = position.position,
                size = new Vector2(position.width, EditorGUIUtility.singleLineHeight)
            };

            SceneAsset oldSceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneNameProperty.stringValue);
            Object sceneAsset = EditorGUI.ObjectField(sceneAssetRect, oldSceneAsset, typeof(SceneAsset), false);
            string sceneAssetPath = AssetDatabase.GetAssetPath(sceneAsset);
            if (sceneNameProperty.stringValue != sceneAssetPath)
            {
                sceneNameProperty.stringValue = sceneAssetPath;
            }

            if (string.IsNullOrEmpty(sceneNameProperty.stringValue))
            {
                sceneIndexProperty.intValue = -1;
                enabledProperty.boolValue = false;
            }

            // Draw preview fields for scene information.
            Rect titleLabelRect = sceneAssetRect;
            titleLabelRect.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(titleLabelRect, ScenePreviewTitle);
            EditorGUI.BeginDisabledGroup(true);
            Rect nameRect = titleLabelRect;
            nameRect.y += EditorGUIUtility.singleLineHeight;

            Rect indexRect = nameRect;
            indexRect.y += EditorGUIUtility.singleLineHeight;

            Rect enabledRect = indexRect;
            enabledRect.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(nameRect, sceneNameProperty);
            EditorGUI.PropertyField(indexRect, sceneIndexProperty);
            EditorGUI.PropertyField(enabledRect, enabledProperty);
            EditorGUI.EndDisabledGroup();

            if (changeCheck.changed)
                property.serializedObject.ApplyModifiedProperties();
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * FieldCount +
                   (FieldCount - 1) * EditorGUIUtility.standardVerticalSpacing;
        }

        #endregion
    }
}