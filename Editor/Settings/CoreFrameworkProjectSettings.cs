#region Header
// CoreFrameworkProjectSettings.cs
// Author: James LaFritz
// Description: ScriptableSingleton for managing Core Framework project-specific settings.
#endregion

using CoreFramework.Settings;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Settings
{
    /// <summary>
    /// ScriptableSingleton for managing Core Framework project-specific settings.
    /// </summary>
    [FilePath("ProjectSettings/CoreFrameworkProjectSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class CoreFrameworkProjectSettings : ScriptableSingleton<CoreFrameworkProjectSettings>
    {
        /// <summary>
        /// The name of the initial scene to start the application.
        /// </summary>
        [SerializeField] private string _startScene;
        
        /// <summary>
        /// The name of the bootstrapper scene that initializes the application.
        /// </summary>
        [SerializeField] private string _bootScene;

        /// <summary>
        /// Gets or sets the name of the initial scene to start the application.
        /// </summary>
        public string StartScene
        {
            get => _startScene;
            set
            {
                _startScene = value;
                CoreFrameWorkSettings.BootScene = value;
                Save(true);
            }
        }

        /// <summary>
        /// Gets or sets the name of the bootstrapper scene that initializes the application.
        /// </summary>
        public string BootScene
        {
            get => _bootScene;
            set
            {
                _bootScene = value;
                CoreFrameWorkSettings.BootScene = value;
                Save(true);
            }
        }
    }
}