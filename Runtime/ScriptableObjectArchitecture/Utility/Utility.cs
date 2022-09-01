namespace CoreFramework.ScriptableObjectArchitecture
{
    /// <summary>
    /// Static Utility Class to Hold Needed Variables.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// The asset menu order variables.
        /// </summary>
        public const int AssetMenuOrderVariables = 10;

        /// <summary>
        /// The asset menu order events.
        /// </summary>
        public const int AssetMenuOrderEvents = 40;

        /// <summary>
        /// The variable submenu.
        /// </summary>
        public const string VariableSubmenu = CoreFrameworkMenu.MainMenu + "Variables/";

        /// <summary>
        /// The variable Structs submenu.
        /// </summary>
        public const string StructsSubmenu = VariableSubmenu + "Structs/";

        /// <summary>
        /// The variable Advanced submenu
        /// </summary>
        public const string AdvancedVariableSubmenu = VariableSubmenu + "Advanced/";

        /// <summary>
        /// The game event submenu.
        /// </summary>
        public const string GameEvent = CoreFrameworkMenu.MainMenu + "Game Events/";

        /// <summary>
        /// The game event Structs submenu
        /// </summary>
        public const string GameEventStructs = GameEvent + "Structs/";

        /// <summary>
        /// The game event Advanced submenu
        /// </summary>
        public const string AdvancedGameEvent = GameEvent + "Advanced/";

        /// <summary>
        /// The add component root menu
        /// </summary>
        public const string AddComponentRootMenu = "Scriptable Object Architecture/";

        /// <summary>
        /// The add component Event Listener menu
        /// </summary>
        public const string EventListenerSubmenu = AddComponentRootMenu + "Event Listeners/";
    }
}