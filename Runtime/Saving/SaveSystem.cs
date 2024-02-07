using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CoreFramework.Saving.VersionControl;

namespace CoreFramework.Saving
{
    /// <summary>
    /// A <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a> that
    /// provides the interface to the Json saving system.
    /// <p>
    /// Uses <a hfre="https://www.newtonsoft.com/json/help/html/Introduction.htm">Json.NET</a>
    /// to provide methods to save and restore all <see cref="SavableEntity"/> in a scene.
    /// </p>
    /// <p>This component should be created once and shared between all subsequent scenes.</p>
    /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    public class SaveSystem : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Config Data")]
        [Tooltip("Toggle this to true if you want the saving system to save state for inactive objects.")]
        [SerializeField]
        private bool includeInactive;

        [SerializeField] private SavingStrategy strategy;

        #endregion

        #region Public Methods

        /// <summary>
        /// Will load the last scene that was saved and restore the state. This must be run as a coroutine.
        /// Loads the Scene in the background as the current Scene runs.
        /// </summary>
        /// <param name="saveFile">The save file name to consult for loading.</param>
        /// <returns>Waits for the Scene Manager to fully load the new scene.</returns>
        public IEnumerator LoadLastScene(string saveFile)
        {
            var buildIndex = SceneManager.GetActiveScene().buildIndex;
            IDictionary<string, JToken> state = LoadFile(saveFile);
            if (state.ContainsKey("lastSceneBuildIndex"))
            {
                buildIndex = (int)state["lastSceneBuildIndex"];
            }

            yield return SceneManager.LoadSceneAsync(buildIndex);
            RestoreState(state);
        }
        
        /// <summary>
        /// Load the scene from the provided save file.
        /// </summary>
        /// <param name="saveFile">The name of the save file to Load from.</param>
        public void Load(string saveFile)
        {
            RestoreState(LoadFile(saveFile));
        }

        /// <summary>
        /// Save the current scene to the provided save file.
        /// </summary>
        /// <param name="saveFile">The name of the file to save to.</param>
        public void Save(string saveFile)
        {
            IDictionary<string, JToken> state = LoadFile(saveFile);
            CaptureState(state);
            SaveFile(saveFile, state);
        }

        /// <summary>
        /// Delete the state in the given save file.
        /// </summary>
        /// <param name="saveFile">The name of the save file to Delete</param>
        public void Delete(string saveFile)
        {
            if (!strategy) return;
            File.Delete(strategy.GetPath(saveFile)!);
        }

        public IEnumerable<string> ListSaves()
        {
            if (strategy == null) return Enumerable.Empty<string>();

            return Directory.EnumerateFiles(SavingStrategy.BasePath!, "*" + strategy.Extension)
                .Select(Path.GetFileNameWithoutExtension);
        }

        #endregion

        #region Private Methods

        private IDictionary<string, JToken> LoadFile(string saveFile)
        {
            if (!strategy)
            {
                Debug.LogError("Saving strategy is null. Please set a saving strategy in the inspector.");
                return new JObject().ToObject<IDictionary<string, JToken>>();
            }

            JObject stateObject = strategy.LoadFromFile(saveFile);
            IDictionary<string, JToken> state = stateObject.ToObject<JObject>();
            if (state == null) return new JObject().ToObject<IDictionary<string, JToken>>();
            
            var currentFileVersion = 0;
            if (state.ContainsKey("CurrentFileVersion"))
            {
                currentFileVersion = (int)state["CurrentFileVersion"];
            }

            if (currentFileVersion >= CurrentFileVersion || currentFileVersion >= MinFileVersion)
                return state;

            Debug.LogWarning("Save file is from an older version of the game and is not supported. " +
                             $"Expected version: {CurrentFileVersion}, " +
                             $"Minimum Expected version: {MinFileVersion}, " +
                             $"Current version: {currentFileVersion}");
            return new JObject().ToObject<IDictionary<string, JToken>>();
        }

        private void SaveFile(string saveFile, IDictionary<string, JToken> state)
        {
            if (!strategy)
            {
                Debug.LogError("Saving strategy is null. Please set a saving strategy in the inspector.");
                return;
            }

            strategy.SaveToFile(saveFile, JObject.FromObject(state!));
        }

        private void CaptureState(IDictionary<string, JToken> state)
        {
            state["CurrentFileVersion"] = CurrentFileVersion;
            foreach (SavableEntity entity in FindObjectsOfType<SavableEntity>(includeInactive))
            {
                state[entity.GetUniqueIdentifier()!] = entity.Capture();
            }

            state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;
        }

        private void RestoreState(IDictionary<string, JToken> state)
        {
            var currentFileVersion = 0;
            if (state.ContainsKey("CurrentFileVersion"))
            {
                currentFileVersion = (int)state["CurrentFileVersion"];
            }

            foreach (SavableEntity entity in FindObjectsOfType<SavableEntity>(includeInactive))
            {
                var id = entity.GetUniqueIdentifier();
                if (!string.IsNullOrWhiteSpace(id) && state.ContainsKey(id))
                {
                    entity.Restore(state[id], currentFileVersion);
                }
            }
        }

        #endregion
    }
}