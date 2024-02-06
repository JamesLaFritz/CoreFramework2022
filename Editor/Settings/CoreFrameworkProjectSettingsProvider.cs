#region Header
// CoreFrameworkProjectSettingsProvider.cs
// Author: James LaFritz
// Description: Custom settings provider for managing Core Framework project settings in the Unity Editor.
#endregion

using System.Collections.Generic;
using System.Linq;
using CoreFrameworkEditor.Attributes;
using UnityEditor;

namespace CoreFrameworkEditor.Settings
{
    /// <summary>
    /// Custom settings provider for managing Core Framework project settings in the Unity Editor.
    /// </summary>
    public class CoreFrameworkProjectSettingsProvider : SettingsProvider
    {
        /// <summary>
        /// The path of the settings provider in the Project Settings window.
        /// </summary>
        private const string SettingsPath = "Project/Core Framework/Settings";

        /// <summary>
        /// Creates a new instance of the CoreFrameworkProjectSettingsProvider.
        /// </summary>
        /// <param name="path">The path of the settings provider.</param>
        /// <param name="scopes">The scope of the settings provider (default is SettingsScope.Project).</param>
        /// <param name="keywords">Keywords for the settings provider.</param>
        private CoreFrameworkProjectSettingsProvider(string path, SettingsScope scopes = SettingsScope.Project,
            IEnumerable<string> keywords = null) : base(path, scopes, keywords) {}

        #region Overrides of SettingsProvider

        /// <inheritdoc />
        public override void OnGUI(string searchContext)
        {
            // Retrieve available scenes
            var scenes = SceneAttributePropertyDrawer.GetScenes() ?? new[] { "" };
            var scenesList = scenes.ToList();

            // Insert "None" option if more than one scene is available
            if (scenesList.Count > 1)
            {
                scenesList.Insert(0, "None");
                scenes = scenesList.ToArray();
            }

            // Get current project settings
            var settings = CoreFrameworkProjectSettings.instance;

            // Get indices for selected scenes
            var selectedStartSceneIndex =
                scenes.Contains(settings.StartScene) ? scenesList.IndexOf(settings.StartScene) : 0;
            var selectedBootSceneIndex =
                scenes.Contains(settings.BootScene) ? scenesList.IndexOf(settings.BootScene) : 0;

            // Display dropdowns for selecting Boot Scene and Start Scene
            settings.BootScene = scenesList[EditorGUILayout.Popup("Boot Scene", selectedBootSceneIndex, scenes)];
            settings.StartScene = scenesList[EditorGUILayout.Popup("Start Scene", selectedStartSceneIndex, scenes)];
        }

        #endregion

        /// <summary>
        /// Creates an instance of the CoreFrameworkProjectSettingsProvider and registers it with the [SettingsProvider] attribute.
        /// </summary>
        /// <returns>The created CoreFrameworkProjectSettingsProvider instance.</returns>
        [SettingsProvider]
        public static SettingsProvider CreateCoreFrameworkProjectSettingsProvider() =>
            new CoreFrameworkProjectSettingsProvider(SettingsPath);

        /// <summary>
        /// Opens the Project Settings window at the specified path when the menu item is selected.
        /// </summary>
        [MenuItem("Core Framework/Project Settings", priority = 0)]
        private static void ProjectSettingsMenuItem() => SettingsService.OpenProjectSettings(SettingsPath);
    }
}