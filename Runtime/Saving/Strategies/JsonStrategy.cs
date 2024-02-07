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