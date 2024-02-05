#region Header
// CoreFrameworkSettingInitialization.cs
#endregion

using CoreFramework.Settings;
using UnityEditor;

namespace CoreFrameworkEditor.Settings
{
    [InitializeOnLoad]
    public static class CoreFrameworkSettingInitialization
    {
        static CoreFrameworkSettingInitialization()
        {
            var preferences = CoreFrameworkPreferences.instance;
            CoreFrameWorkSettings.ShowDebug = preferences.ShowDebug;
            CoreFrameWorkSettings.InfoSize = preferences.InfoSize;
            CoreFrameWorkSettings.WarningSize = preferences.WarningSize;
            CoreFrameWorkSettings.ErrorSize = preferences.ErrorSize;

            var projectSettings = CoreFrameworkProjectSettings.instance;
            CoreFrameWorkSettings.StartScene = projectSettings.StartScene;
            CoreFrameWorkSettings.BootScene = projectSettings.BootScene;
        }
    }
}