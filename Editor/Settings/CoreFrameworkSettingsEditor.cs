using System.Linq;
using CoreFramework;
using CoreFramework.Settings;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Settings
{
    public class CoreFrameworkSettingsEditor : EditorWindow
    {
        private GUIContent _settingsGUIContent;
        
        private VisualElement _rootElement;
        private ObjectField _settingsObjectField;
        
        [MenuItem(CoreFrameworkMenu.MainMenu + "Settings")]
        private static void Init()
        {
            var window = GetWindow<CoreFrameworkSettingsEditor>();
            window.titleContent = new GUIContent("Settings");
            window.Show();
        }
        
        private void CreateGUI()
        {
            // This replaces OnGUI and sets up the UIElements UI
            _rootElement = rootVisualElement;
            
            // Create and add a new VisualElement to the root
            var container = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Column
                }
            };
            _rootElement.Add(container);

            // Create an object field and add it to the container
            _settingsObjectField = new ObjectField("Core Framework Settings SO")
            {
                objectType = typeof(CoreFrameworkSettingsSO),
                value = CoreFrameWorkSettings.settingsSO
            };
            _settingsObjectField.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO = evt.newValue as CoreFrameworkSettingsSO;
                RefreshSettings();
            });
            container.Add(_settingsObjectField);

            // Call this to draw the rest of the settings once the scriptable object is assigned
            RefreshSettings();
        }
        
        private void RefreshSettings()
        {
            // Clear previous settings display
            var settingsDisplay = _rootElement.Q("settingsDisplay");
            settingsDisplay?.Clear();

            // Only display settings if the scriptable object is assigned
            if (CoreFrameWorkSettings.settingsSO == null) return;
            // Create a new VisualElement to hold the settings display and add it to the root
            settingsDisplay = new VisualElement
            {
                name = "settingsDisplay"
            };
            _rootElement.Add(settingsDisplay);

            // Call methods to draw different settings sections
            DrawSceneSettings(settingsDisplay);
            DrawDebugSettings(settingsDisplay);
        }

        private static void DrawDebugSettings(VisualElement container)
        {
            var debugSettingsLabel = new Label("Debug Settings")
            {
                style =
                {
                    fontSize = 14,
                    unityFontStyleAndWeight = FontStyle.Bold
                }
            };
            container.Add(debugSettingsLabel);

            var showDebugToggle = new Toggle("Show Debug Info")
            {
                value = CoreFrameWorkSettings.settingsSO.showDebug
            };
            showDebugToggle.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO.showDebug = evt.newValue;
            });
            container.Add(showDebugToggle);

            var infoSizeField = new IntegerField("Info Size")
            {
                value = CoreFrameWorkSettings.settingsSO.infoSize
            };
            infoSizeField.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO.infoSize = evt.newValue;
            });
            container.Add(infoSizeField);

            var warningSizeField = new IntegerField("Warning Size")
            {
                value = CoreFrameWorkSettings.settingsSO.warningSize
            };
            warningSizeField.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO.warningSize = evt.newValue;
            });
            container.Add(warningSizeField);

            var errorSizeField = new IntegerField("Error Size")
            {
                value = CoreFrameWorkSettings.settingsSO.errorSize
            };
            errorSizeField.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO.errorSize = evt.newValue;
            });
            container.Add(errorSizeField);
        }

        private void DrawSceneSettings(VisualElement container)
        {
            // Scene Settings Label
            var sceneSettingsLabel = new Label("Scene Settings")
            {
                style =
                {
                    fontSize = 14,
                    unityFontStyleAndWeight = FontStyle.Bold
                }
            };
            container.Add(sceneSettingsLabel);

            // Check if there are any scenes in the build settings
            if (!Attributes.SceneAttributePropertyDrawer.AnySceneInBuildSettings)
            {
                var helpBox = new HelpBox(
                    "No scenes in the build settings. Please add your scenes to File->Build Settings->Scenes In Build.",
                    HelpBoxMessageType.Error);
                container.Add(helpBox);
                return;
            }

            var scenes = Attributes.SceneAttributePropertyDrawer.GetScenes();
            var sceneOptions = Attributes.SceneAttributePropertyDrawer.GetSceneOptions(scenes).ToList();
            var scenesList = scenes!.ToList();

            // Boot Scene Popup
            var bootSceneIndex = scenesList.IndexOf(CoreFrameWorkSettings.settingsSO.bootSceneScene);
            var bootScenePopup = new PopupField<string>("Boot Scene", sceneOptions, bootSceneIndex);
            bootScenePopup.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO.bootSceneScene = scenesList[sceneOptions.IndexOf(evt.newValue)];
            });
            container.Add(bootScenePopup);
            
            // Start Scene Popup
            var startSceneIndex = scenesList.IndexOf(CoreFrameWorkSettings.settingsSO.startScene);
            var startScenePopup = new PopupField<string>("Start Scene", sceneOptions, startSceneIndex);
            startScenePopup.RegisterValueChangedCallback(evt =>
            {
                CoreFrameWorkSettings.settingsSO.startScene = scenesList[sceneOptions.IndexOf(evt.newValue)];
            });
            container.Add(startScenePopup);
        }
    }
}