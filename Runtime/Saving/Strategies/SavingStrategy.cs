#region Header
// SavingStrategy.cs
// Author: James LaFritz
// Description: 
// Represents an abstract strategy pattern implementation for saving game data. The class provides a foundation
// for creating specific saving mechanisms by exposing methods for saving and loading states. Derived classes
// will implement the concrete behavior for reading and writing save files based on the data captured by Capture 
// and Restore methods.
//
// The class utilizes the power of Newtonsoft Json.NET library to represent the state as a JObject, 
// which offers flexibility in serializing and deserializing complex data structures.
//
// Developers can use different saving strategies (e.g., binary, XML, JSON) by extending this abstract class and 
// implementing the required methods.
//
// Reference: [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)
#endregion

using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace CoreFramework.Saving
{
    /// <summary>
    /// Represents an abstract strategy pattern implementation for saving game data. The class provides a foundation
    /// for creating specific saving mechanisms by exposing methods for saving and loading states. Derived classes
    /// will implement the concrete behavior for reading and writing save files based on the data captured by Capture 
    /// and Restore methods.
    ///
    /// The class utilizes the power of Newtonsoft Json.NET library to represent the state as a JObject, 
    /// which offers flexibility in serializing and deserializing complex data structures.
    ///
    /// Developers can use different saving strategies (e.g., binary, XML, JSON) by extending this abstract class and 
    /// implementing the required methods.
    ///
    /// Reference: [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)
    /// </summary>
    public abstract class SavingStrategy : ScriptableObject
    {
        private const string SaveFolder = "Saves";

        /// <summary>
        /// <value>The Path to Load From or Save to.</value>
        /// <returns>Path.Combine(Application.persistentDataPath!, SaveFolder);</returns>
        /// </summary>
        public static string BasePath => Path.Combine(Application.persistentDataPath!, SaveFolder);

        /// <summary>
        /// <value>The Extension to use for the save file.</value>
        /// </summary>
        public abstract string Extension { get; }

        /// <summary>
        /// Save the state to a file.
        /// </summary>
        /// <param name="saveFile">The name of the save file without extensions.</param>
        /// <param name="state"><a href="https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm">JObject</a> that represents the state.</param>
        public abstract void SaveToFile(string saveFile, JObject state);

        /// <summary>
        /// Load the state from a file.
        /// </summary>
        /// <param name="saveFile">The name of the save file without extensions.</param>
        /// <returns><a href="https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm">JObject</a> that represents the state.</returns>
        public abstract JObject LoadFromFile(string saveFile);

        /// <summary>
        /// Gets the path to the save file.
        /// If the Directory does not exist it will be created.
        /// </summary>
        /// <param name="saveFile">The name of the save file without extensions.</param>
        /// <returns>Path.Combine(BasePath, saveFile + Extension);</returns>
        public string GetPath(string saveFile)
        {
            if (!Directory.Exists(BasePath)) Directory.CreateDirectory(BasePath!);

            return Path.Combine(BasePath, saveFile + Extension);
        }
    }
}