using Newtonsoft.Json.Linq;

namespace CoreFramework.Saving
{
    /// <summary>
    /// An Interface to Implement in any component that has state to save/restore.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    public interface ISavable
    {
        /// <summary>
        /// Called when saving to capture the state of the Component.
        /// </summary>
        /// <returns><a href="https://www.newtonsoft.com/json/help/html/t_newtonsoft_json_linq_jtoken.htm">JToken</a> object representing the state of the Component.</returns>
        JToken CaptureAsJToken();

        /// <summary>
        /// Called when restoring the state of the Component using the information in JToken.
        /// </summary>
        /// <param name="state"><a href="https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JToken.htm">JToken</a> object representing the state of the Component.</param>
        /// <param name="version">The version number of the saved data.</param>
        void RestoreFromJToken(JToken state, int version);
    }
}