using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture
{
    /// <summary>
    /// Describes a Unity Scene Asset for use as a Scriptable Object Variable
    /// </summary>
    /// <seealso cref="ISerializationCallbackReceiver"/>
    [System.Serializable]
    public sealed class SceneInfo : ISerializationCallbackReceiver
    {
        /// <summary>
        /// The scene name.
        /// </summary>
        [SerializeField] private string sceneName;

        /// <summary>
        /// The scene index.
        /// </summary>
        [SerializeField] private int sceneIndex;

        /// <summary>
        /// Is the scene enabled?
        /// </summary>
        [SerializeField] private bool isSceneEnabled;

        /// <summary>
        /// Returns the fully-qualified name of the scene.
        /// </summary>
        public string SceneName => sceneName;

        /// <summary>
        /// Returns the index of the scene in the build settings; if not present, -1 will be returned instead.
        /// </summary>
        public int SceneIndex
        {
            get => sceneIndex;
            internal set => sceneIndex = value;
        }

        /// <summary>
        /// Returns true if the scene is present in the build settings, otherwise false.
        /// </summary>
        public bool IsSceneInBuildSettings => sceneIndex != -1;

        /// <summary>
        /// Returns true if the scene is enabled in the build settings, otherwise false.
        /// </summary>
        public bool IsSceneEnabled
        {
            get => isSceneEnabled;
            internal set => isSceneEnabled = value;
        }

        #if UNITY_EDITOR
        public UnityEditor.SceneAsset Scene =>
            UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEditor.SceneAsset>(sceneName);
        #endif

        #region Implementation of ISerializationCallbackReceiver

        /// <inheritdoc />
        public void OnBeforeSerialize()
        {
            #if UNITY_EDITOR
            if (Scene == null) return;
            string sceneAssetPath = UnityEditor.AssetDatabase.GetAssetPath(Scene);
            string sceneAssetGuid = UnityEditor.AssetDatabase.AssetPathToGUID(sceneAssetPath);
            UnityEditor.EditorBuildSettingsScene[] scenes = UnityEditor.EditorBuildSettings.scenes;

            SceneIndex = -1;
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i].guid.ToString() != sceneAssetGuid) continue;
                SceneIndex = i;
                IsSceneEnabled = scenes[i].enabled;
                break;
            }
            #endif
        }

        /// <inheritdoc />
        public void OnAfterDeserialize() { }

        #endregion
    }
}