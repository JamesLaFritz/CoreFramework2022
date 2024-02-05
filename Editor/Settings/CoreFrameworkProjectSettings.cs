#region Header
// CoreFrameworkProjectSettings.cs
#endregion

using CoreFramework.Attributes;
using CoreFramework.Settings;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Settings
{
    [FilePath("ProjectSettings/CoreFrameworkProjectSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class CoreFrameworkProjectSettings : ScriptableSingleton<CoreFrameworkProjectSettings>
    {
        [SerializeField] private string _startScene;
        [SerializeField] private string _bootScene;

        /// <summary>
        /// The name of the initial scene to start the application.
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
        /// The name of the bootstrapper scene that initializes the application.
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