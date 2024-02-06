#region Header
// SavableEntity.cs
// Author: James LaFritz
// Description: 
// A MonoBehaviour for all game objects that need to save data.
// This class provides functionality to save and load the state of game objects in Unity.
// for all game objects that need to save data.
//
// This class gives the GameObject a unique ID in the scene file. The ID is
// used for saving and restoring the state related to this GameObject. This
// ID can be manually overridden to link GameObjects between scenes (such as
// recurring characters, the player, or a score board). Take care not to set
// this in a prefab unless you want to link all instances between scenes.
// UnityEngine.ExecuteAlways
#endregion

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CoreFramework.Saving
{
    /// <summary>
    /// A <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a>
    /// for all game objects that need to save data.
    /// To be placed on any GameObject that has <see cref="ISavable"/> components that
    /// require saving.
    ///
    /// This class gives the GameObject a unique ID in the scene file. The ID is
    /// used for saving and restoring the state related to this GameObject. This
    /// ID can be manually overridden to link GameObjects between scenes (such as
    /// recurring characters, the player, or a score board). Take care not to set
    /// this in a prefab unless you want to link all instances between scenes.
    /// [UnityEngine.ExecuteAlways](https://docs.unity3d.com/ScriptReference/ExecuteAlways.html)
    /// </summary>
    /// <remarks>
    /// To be placed on any GameObject that has `ISavable` components that
    /// require saving.
    /// </remarks>
    [ExecuteAlways]
    public class SavableEntity : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Config Data")]
        [Tooltip("The unique ID is automatically generated in a scene file if " +
                 "left empty. Do not set in a prefab unless you want all instances to " +
                 "be linked.")]
        [SerializeField]
        private string _uniqueIdentifier = "";

        /// <summary>
        /// Flag to determine if debug log information should be displayed.
        /// </summary>
        [Header("Debug")] [SerializeField] private bool _logInfo;

        #endregion

        /// <summary>
        /// A static cache of SavableEntity instances by their unique identifiers.
        /// </summary>
        private static readonly Dictionary<string, SavableEntity> GlobalLookup = new();

        #region Public Methods

        /// <summary>
        /// Get the Unique Identifier for this object.
        /// </summary>
        /// <returns>Unique Identifier for this object.</returns>
        public string GetUniqueIdentifier()
        {
            return _uniqueIdentifier;
        }

        /// <summary>
        /// Captures and returns the state of all `ISavable` components attached to the GameObject.
        /// </summary>
        /// <returns>A [JToken](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JToken.htm) object representing the state of the entity.</returns>
        public JToken Capture()
        {
            JObject state = new();
            IDictionary<string, JToken> stateDict = state;
            foreach (ISavable jsonSavable in GetComponents<ISavable>())
            {
                JToken token = jsonSavable.CaptureAsJToken();
                var component = jsonSavable.GetType().ToString();
                LogToken(component, token, "Capture");
                stateDict[jsonSavable.GetType().ToString()!] = jsonSavable.CaptureAsJToken();
            }

            return state;
        }

        /// <summary>
        /// Restores the state of all `ISavable` components on the GameObject using the provided state data.
        /// </summary>
        /// <param name="state">A [JToken](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JToken.htm) object representing the state of the entity.</param>
        /// <param name="currentFileVersion">The current version of the save file to ensure compatibility.</param>
        public void Restore(JToken state, int currentFileVersion)
        {
            IDictionary<string, JToken> stateDict = state.ToObject<JObject>();
            if (stateDict == null) return;
            foreach (ISavable jsonSavable in GetComponents<ISavable>())
            {
                var component = jsonSavable.GetType().ToString();
                if (!stateDict.ContainsKey(component!)) continue;
                JToken token = stateDict[component];
                LogToken(component, token, "Restore");
                jsonSavable.RestoreFromJToken(token, currentFileVersion);
            }
        }

        #endregion

        #region Unity Messages (Unity Editor Only)

        #if UNITY_EDITOR
        /// <summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html"/>
        /// </summary>
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrWhiteSpace(gameObject.scene.path)) return;

            SerializedObject serializedObject = new(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (string.IsNullOrWhiteSpace(property.stringValue) ||
                !IsUnique(property.stringValue))
            {
                property.stringValue = $"{name}-{System.Guid.NewGuid()}";
                serializedObject.ApplyModifiedProperties();
            }

            GlobalLookup[property.stringValue] = this;
        }
        #endif

        #endregion

        #region Private Methods

        private void LogToken(string component, JToken token, string callingMethod)
        {
            if (!_logInfo) return;
            var message = $"<color=blue>{name}:</color> <color=brown>{callingMethod}:</color>";
            message += $" <color=darkblue>{component ?? "null"}</color>";
            message += $" = <color=teal>{token ?? "null"}</color>";
            message = Regex.Replace(message, @"\r\n?|\n", "");
            Debug.Log(message);
        }


        private bool IsUnique(string candidate)
        {
            if (string.IsNullOrWhiteSpace(candidate)) return false;
            if (!GlobalLookup.ContainsKey(candidate)) return true;

            if (GlobalLookup[candidate] == this) return true;

            if (!GlobalLookup[candidate])
            {
                GlobalLookup.Remove(candidate);
                return true;
            }

            if (GlobalLookup[candidate].GetUniqueIdentifier() == candidate) return false;
            GlobalLookup.Remove(candidate);
            return true;
        }

        #endregion
    }
}
