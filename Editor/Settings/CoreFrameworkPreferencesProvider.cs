#region Header
// CoreFrameworkPreferencesProvider.cs
#endregion

using System.Collections.Generic;
using UnityEditor;

namespace CoreFrameworkEditor.Settings
{
    public class CoreFrameworkPreferencesProvider : SettingsProvider
    {
        /// <inheritdoc />
        private CoreFrameworkPreferencesProvider(string path, SettingsScope scopes
            , IEnumerable<string> keywords = null) : base(path, scopes, keywords) {}

        #region Overrides of SettingsProvider

        /// <inheritdoc />
        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);

            var preferences = CoreFrameworkPreferences.instance;

            preferences.ShowDebug = EditorGUILayout.ToggleLeft("Show Debug", preferences.ShowDebug);
            preferences.InfoSize = EditorGUILayout.IntSlider("Info Size", preferences.InfoSize, 10, 20);
            preferences.WarningSize = EditorGUILayout.IntSlider("Warning Size", preferences.WarningSize, 10, 20);
            preferences.ErrorSize = EditorGUILayout.IntSlider("Error Size", preferences.ErrorSize, 10, 20);
        }

        #endregion

        [SettingsProvider]
        public static SettingsProvider CreateCoreFrameworkPreferencesProvider() =>
            new CoreFrameworkPreferencesProvider("Preferences/Core Framework/Settings", SettingsScope.User);
    }
}