namespace CoreFramework.Settings
{
    public static class CoreFrameWorkSettings
    {
        public static CoreFrameworkSettingsSO settingsSO;

        public static string StartScene => settingsSO == null ? "SampleScene" : settingsSO.startScene;

        public static string BootScene => settingsSO == null ? "Bootstrapper" : settingsSO.startScene;

        public static bool ShowDebug => settingsSO == null || settingsSO.showDebug;

        public static int InfoSize => settingsSO == null ? 14 : settingsSO.infoSize;
        public static int WarningSize => settingsSO == null ? 15 : settingsSO.infoSize;
        public static int ErrorSize => settingsSO == null ? 16 : settingsSO.infoSize;
    }
}