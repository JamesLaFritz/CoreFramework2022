#region Header
// SaveSystem.cs
// Author: James LaFritz
// Description: MonoBehaviour script responsible for interfacing with the Json saving system in the Core Framework.
// This script manages the saving and loading of game states, including the state of all SavableEntity 
// objects within a Unity scene. It ensures game progress and configurations are persisted and can 
// be loaded across game sessions or after game restarts.
//
// It provides methods to save, load, and delete game states to and from specified save files. Additionally, 
// it uses the Json.NET library for serializing and deserializing game state data.
//
// Only one instance of this component should exist, and it should be shared across all scenes.
#endregion


using System;
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
        private bool _includeInactive;

        /// <summary>
        /// This field is a reference to the saving strategy that will be used by the save system. 
        /// The `SavingStrategy` is an abstract class or interface which can have different implementations,
        /// such as saving to JSON, binary, etc.
        /// </summary>
        [SerializeField] private SavingStrategy _strategy;

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
            if (!_strategy) return;
            File.Delete(_strategy.GetPath(saveFile)!);
        }

        public IEnumerable<string> ListSaves()
        {
            if (_strategy == null) return Enumerable.Empty<string>();

            return Directory.EnumerateFiles(SavingStrategy.BasePath!, "*" + _strategy.Extension)
                .Select(Path.GetFileNameWithoutExtension);
        }

        #endregion

        #region Private Methods

        private IDictionary<string, JToken> LoadFile(string saveFile)
        {
            if (!_strategy)
            {
                Debug.LogError("Saving strategy is null. Please set a saving strategy in the inspector.");
                return new JObject().ToObject<IDictionary<string, JToken>>();
            }

            var stateObject = _strategy.LoadFromFile(saveFile);
            IDictionary<string, JToken> state = stateObject.ToObject<JObject>();
            if (state == null) return new JObject().ToObject<IDictionary<string, JToken>>();
            
            var currentFileVersion = new Version();
            if (state.TryGetValue("CurrentFileVersion", out var value))
            {
                if (!Version.TryParse(value.ToString(), out currentFileVersion))
                {
                    Debug.LogError("Save file has been corrupted. " +
                                   $"Expected version: {CurrentFileVersion}, " +
                                   $"Minimum Expected version: {MinFileVersion}");
                }
                else if (currentFileVersion >= CurrentFileVersion || currentFileVersion >= MinFileVersion)
                    return state;
            }

            Debug.LogWarning("Save file is from an older version of the game and is not supported. " +
                             $"Expected version: {CurrentFileVersion}, " +
                             $"Minimum Expected version: {MinFileVersion}, " +
                             $"Current version: {currentFileVersion}");
            return new JObject().ToObject<IDictionary<string, JToken>>();
        }

        private void SaveFile(string saveFile, IDictionary<string, JToken> state)
        {
            if (!_strategy)
            {
                Debug.LogError("Saving strategy is null. Please set a saving strategy in the inspector.");
                return;
            }

            _strategy.SaveToFile(saveFile, JObject.FromObject(state!));
        }

        private void CaptureState(IDictionary<string, JToken> state)
        {
            state["CurrentFileVersion"] = CurrentFileVersion.ToString();
            foreach (var entity in FindObjectsOfType<SavableEntity>(_includeInactive))
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

            foreach (var entity in FindObjectsOfType<SavableEntity>(_includeInactive))
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