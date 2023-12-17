namespace CoreFramework.Settings
{
    public static class CoreFrameWorkSettings
    {
        public static CoreFrameworkSettingsSO settingsSO;

        /// <summary>
        /// The name of the starting scene. Defaults to "SampleScene" if SettingsSO is not set.
        /// </summary>
        public static string StartScene => SettingsSO == null ? null : SettingsSO.startScene;

        /// <summary>
        /// The name of the boot scene. Defaults to "Bootstrapper" if SettingsSO is not set.
        /// </summary>
        public static string BootScene => SettingsSO == null ? null : SettingsSO.bootScene;

        public static bool ShowDebug => settingsSO == null || settingsSO.showDebug;

        public static int InfoSize => settingsSO == null ? 14 : settingsSO.infoSize;
        public static int WarningSize => settingsSO == null ? 15 : settingsSO.infoSize;
        public static int ErrorSize => settingsSO == null ? 16 : settingsSO.infoSize;
    }
}