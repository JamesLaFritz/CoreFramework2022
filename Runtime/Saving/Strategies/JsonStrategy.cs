#region Header
// JsonStrategy.cs
// Author: James LaFritz
// Description: 
// Represents a concrete implementation of the SavingStrategy that provides the mechanism 
// to save and load game data as JSON files. Utilizing Newtonsoft's Json.NET library, the strategy offers 
// a human-readable way of representing game states and allows developers to serialize and deserialize 
// complex data structures into and from JSON format.
//
// The class exposes methods to save a game state to a JSON file and load a state from a JSON file. 
// Developers can easily incorporate the strategy into their Unity project, offering a straightforward 
// mechanism for managing game saves in JSON format.
//
// Reference: [CreateAssetMenu(menuName = "SavingStrategies/Json", fileName = "JsonStrategy")]
#endregion


using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace CoreFramework.Saving
{
    /// <summary>
    /// A <see cref="SavingStrategy"/> that Saves and Loads in the form of a JSON string.
    /// </summary>
    [CreateAssetMenu(menuName = "SavingStrategies/Json", fileName = "JsonStrategy")]
    public class JsonStrategy : SavingStrategy
    {
        #region Overrides of SavingStrategy

        /// <inheritdoc />
        public override string Extension => ".json";

        /// <inheritdoc />
        public override void SaveToFile(string saveFile, JObject state)
        {
            var path = GetPath(saveFile);
            Debug.Log($"Saving to {path} ");
            using StreamWriter textWriter = File.CreateText(path!);
            using JsonTextWriter writer = new JsonTextWriter(textWriter);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, state);
        }

        /// <inheritdoc />
        public override JObject LoadFromFile(string saveFile)
        {
            var path = GetPath(saveFile);
            if (!File.Exists(path))
            {
                return new JObject();
            }

            using StreamReader textReader = File.OpenText(path!);
            using JsonTextReader reader = new JsonTextReader(textReader);
            reader.FloatParseHandling = FloatParseHandling.Double;

            return JObject.Load(reader);
        }

        #endregion
    }
}