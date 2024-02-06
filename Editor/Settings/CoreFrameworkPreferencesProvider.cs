#region Header
// CoreFrameworkPreferencesProvider.cs
// Author: James LaFritz
#endregion

using System.Collections.Generic;
using UnityEditor;

namespace CoreFrameworkEditor.Settings
{
    public class CoreFrameworkPreferencesProvider : SettingsProvider
    {
        private const string SettingsPath = "Preferences/Core Framework/Settings";
        
        /// <inheritdoc />
        private CoreFrameworkPreferencesProvider(string path, SettingsScope scopes = SettingsScope.User,
            IEnumerable<string> keywords = null) : base(path, scopes, keywords) {}

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
            new CoreFrameworkPreferencesProvider(SettingsPath);

        [MenuItem("Core Framework/Preference Settings", priority = 1)]
        private static void ProjectSettingsMenuItem() => SettingsService.OpenUserPreferences(SettingsPath);
    }
}