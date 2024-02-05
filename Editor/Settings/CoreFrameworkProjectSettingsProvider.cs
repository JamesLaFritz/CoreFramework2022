#region Header
// CoreFrameworkProjectSettingsProvider.cs
#endregion

using System.Collections.Generic;
using System.Linq;
using CoreFrameworkEditor.Attributes;
using UnityEditor;

namespace CoreFrameworkEditor.Settings
{
    public class CoreFrameworkProjectSettingsProvider : SettingsProvider
    {
        /// <inheritdoc />
        private CoreFrameworkProjectSettingsProvider(string path, SettingsScope scopes
            , IEnumerable<string> keywords = null) : base(path, scopes, keywords) {}

        #region Overrides of SettingsProvider

        /// <inheritdoc />
        public override void OnGUI(string searchContext)
        {
            var scenes = SceneAttributePropertyDrawer.GetScenes() ?? new[] { "" };
            var scenesList = scenes!.ToList();
            if (scenesList.Count > 1)
            {
                scenesList.Insert(0, "None");
                scenes = scenesList.ToArray();
            }
            var settings = CoreFrameworkProjectSettings.instance;

            var selectedStartSceneIndex =
                scenes.Contains(settings.StartScene) ? scenesList.IndexOf(settings.StartScene) : 0;
            var selectedBootSceneIndex =
                scenes.Contains(settings.BootScene) ? scenesList.IndexOf(settings.BootScene) : 0;
            
            //property.displayName, scenesList, scenesList.IndexOf(property.stringValue)
            settings.BootScene = scenesList[EditorGUILayout.Popup("Boot Scene", selectedBootSceneIndex, scenes)];
            settings.StartScene = scenesList[EditorGUILayout.Popup("Start Scene", selectedStartSceneIndex, scenes)];
        }

        #endregion

        [SettingsProvider]
        public static SettingsProvider CreateCoreFrameworkProjectSettingsProvider() =>
            new CoreFrameworkProjectSettingsProvider("Project/Core Framework/Settings", SettingsScope.Project);
    }
}