using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace CoreFrameworkEditor.ScriptableObjectArchitecture.Inspectors
{
    /// <summary>
    /// The scene variable editor class
    /// </summary>
    /// <seealso cref="UnityEditor.Editor"/>
    [CustomEditor(typeof(SceneVariable))]
    internal sealed class SceneVariableEditor : Editor
    {
        /// <summary>
        /// The scene not assigned warning
        /// </summary>
        private const string SceneNotAssignedWarning =
            "Please assign a scene as the current serialized values for " +
            "the scene do not resolve to an asset in the project.";

        /// <summary>
        /// The scene not in build settings warning
        /// </summary>
        private const string SceneNotInBuildSettingsWarning =
            "Assigned Scene is not currently in the Build Settings";

        /// <summary>
        /// The scene not enabled in build settings warning
        /// </summary>
        private const string SceneNotEnabledInBuildSettingsWarning =
            "Assigned Scene is present in build settings, but not enabled.";

        /// <summary>
        /// The readonly tooltip
        /// </summary>
        private const string ReadonlyTooltip =
            "A scene variable is essentially a constant for edit-time modification only. " +
            "There is not any kind of expectation for a user to be able to set this at runtime." +
            "May have a gloable variable that changes when it is time to change scenes.";

        /// <summary>
        /// The scene info property
        /// </summary>
        private const string SceneInfoProperty = "m_value";

        /// <summary>
        /// The readonly
        /// </summary>
        private SerializedProperty _readOnly;
        /// <summary>
        /// The raise warning
        /// </summary>
        private SerializedProperty _raiseWarning;
        /// <summary>
        /// The is clamped
        /// </summary>
        private SerializedProperty _isClamped;

        /// <summary>
        /// The raise warning animation
        /// </summary>
        private AnimBool _raiseWarningAnimation;
        /// <summary>
        /// The is clamped variable animation
        /// </summary>
        private AnimBool _isClampedVariableAnimation;

        /// <summary>
        /// Gets the value of the scene variable
        /// </summary>
        private SceneVariable SceneVariable => target as SceneVariable;

        /// <summary>
        /// This function is called when the object is loaded.
        /// </summary>
        private void OnEnable()
        {
            _readOnly = serializedObject.FindProperty("readOnly");
            _raiseWarning = serializedObject.FindProperty("m_raiseWarning");
            _isClamped = serializedObject.FindProperty("m_isClamped");

            _raiseWarningAnimation = new AnimBool(_readOnly.boolValue);
            _raiseWarningAnimation.valueChanged.AddListener(Repaint);

            _isClampedVariableAnimation = new AnimBool(_isClamped.boolValue);
            _isClampedVariableAnimation.valueChanged.AddListener(Repaint);
        }

        #region Overrides of Editor

        /// <inheritdoc />
        public override bool RequiresConstantRepaint()
        {
            return true;
        }

        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawReadOnlyField();
            DrawValue();

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        /// <summary>
        /// Draws the read only field
        /// </summary>
        private void DrawReadOnlyField()
        {
            EditorGUILayout.HelpBox(ReadonlyTooltip, MessageType.Info);
            using (new EditorGUI.DisabledScope(_raiseWarning.boolValue))
            {
                _readOnly.boolValue = EditorGUILayout.ToggleLeft("Read Only", _readOnly.boolValue);
            }

            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_raiseWarning);
            EditorGUI.indentLevel--;
        }

        /// <summary>
        /// Draws the value
        /// </summary>
        private void DrawValue()
        {
            SerializedProperty sceneInfoProperty = serializedObject.FindProperty(SceneInfoProperty);
            // ReSharper disable once Unity.NoNullPropagation
            if (SceneVariable?.Value?.Scene == null)
            {
                EditorGUILayout.HelpBox(SceneNotAssignedWarning, MessageType.Warning);
            }
            else if (!SceneVariable.Value.IsSceneInBuildSettings)
            {
                EditorGUILayout.HelpBox(SceneNotInBuildSettingsWarning, MessageType.Warning);
            }
            else if (!SceneVariable.Value.IsSceneEnabled)
            {
                EditorGUILayout.HelpBox(SceneNotEnabledInBuildSettingsWarning, MessageType.Warning);
            }

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(sceneInfoProperty);
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }
    }
}