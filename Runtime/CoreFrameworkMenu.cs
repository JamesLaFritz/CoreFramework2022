#region Header
// CoreFrameworkMenu.cs
// Author: James LaFritz
// Description: Provides menu path constants to be used with Unity's Editor menu functionalities, ensuring consistent naming across the Core Framework's custom editor options.
#endregion

namespace CoreFramework
{
    public static class CoreFrameworkMenu
    {
        /// <summary>
        /// The main menu path for all Core Framework-related items in the Unity Editor.
        /// </summary>
        /// <example>
        /// <code>[MenuItem(CoreFrameworkMenu.MainMenu + "Custom Option")]
        /// public static void MyCustomMenuOption()
        /// {
        ///     // Implementation for the menu option...
        /// }
        /// </code>   
        /// </example>
        public const string MainMenu = "Core Framework/";
    }
}