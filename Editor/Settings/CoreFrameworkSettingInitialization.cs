#region Header
// CoreFrameworkSettingInitialization.cs
// Author: James LaFritz
// Description: Initialization script for Core Framework settings in the Unity Editor.
//              This script ensures that the preferences and project settings are loaded
//              on editor startup, synchronizing them with the CoreFrameworkSettings.
#endregion

using CoreFramework.Settings;
using UnityEditor;

namespace CoreFrameworkEditor.Settings
{
    /// <summary>
    /// Initialization script for Core Framework settings in the Unity Editor.
    /// This script ensures that the preferences and project settings are loaded
    /// on editor startup, synchronizing them with the CoreFrameworkSettings.
    /// </summary>
    [InitializeOnLoad]
    public static class CoreFrameworkSettingInitialization
    {
        /// <summary>
        /// Static constructor that runs when the class is loaded.
        /// </summary>
        static CoreFrameworkSettingInitialization()
        {
            // Load preferences
            var preferences = CoreFrameworkPreferences.instance;
            CoreFrameWorkSettings.ShowDebug = preferences.ShowDebug;
            CoreFrameWorkSettings.InfoSize = preferences.InfoSize;
            CoreFrameWorkSettings.WarningSize = preferences.WarningSize;
            CoreFrameWorkSettings.ErrorSize = preferences.ErrorSize;

            // Load project settings
            var projectSettings = CoreFrameworkProjectSettings.instance;
            CoreFrameWorkSettings.StartScene = projectSettings.StartScene;
            CoreFrameWorkSettings.BootScene = projectSettings.BootScene;
        }
    }
}