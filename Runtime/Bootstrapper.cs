#region Header
// Bootstrapper.cs
// Author: James LaFritz
// Description: Handles the initial bootstrapping of the application, ensuring that
// essential settings are applied and that the initial scene is loaded.
#endregion

using System;
using CoreFramework.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoreFramework
{
    /// <summary>
    /// Handles the initial bootstrapping of the application, ensuring that
    /// essential settings are applied and that the initial scene is loaded.
    /// </summary>
    [HelpURL("https://jameslafritz.github.io/CoreFramework2022/Manual/Bootstrapper.html")]
    public class Bootstrapper : MonoBehaviour
    {
        /// <summary>
        /// Asynchronously initializes necessary services and loads the starting scene
        /// when the application begins.
        /// </summary>
        private void Start()
        {
            Application.runInBackground = true;
            //await UnityServices.InitializeAsync();

            // Asynchronous initialization of services can be added here.
            // await UnityServices.InitializeAsync();

            if (string.IsNullOrWhiteSpace(CoreFrameWorkSettings.StartScene) ||
                string.Compare(CoreFrameWorkSettings.StartScene, "None", StringComparison.Ordinal) == 0) return;

            // Load the start scene additively if it's the only scene currently loaded.
            if (SceneManager.loadedSceneCount == 1)
                SceneManager.LoadScene(CoreFrameWorkSettings.StartScene, LoadSceneMode.Additive);
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
#if UNITY_EDITOR
            var currentlyLoadedEditorScene = SceneManager.GetActiveScene();
#endif
            if (string.IsNullOrWhiteSpace(CoreFrameWorkSettings.BootScene) ||
                string.Compare(CoreFrameWorkSettings.BootScene, "None", StringComparison.Ordinal) == 0) return;

            // Load the designated boot scene if it's not already loaded.
            if (SceneManager.GetSceneByName(CoreFrameWorkSettings.BootScene).isLoaded != true)
                SceneManager.LoadScene(CoreFrameWorkSettings.BootScene);

#if UNITY_EDITOR
            if (currentlyLoadedEditorScene.IsValid())
                SceneManager.LoadSceneAsync(currentlyLoadedEditorScene.name, LoadSceneMode.Additive);
#else
            if (string.IsNullOrWhiteSpace(CoreFrameWorkSettings.StartScene) ||
                string.Compare(CoreFrameWorkSettings.StartScene, "None", StringComparison.Ordinal) == 0) return;
            // Load the start scene additively in a built game.
            SceneManager.LoadSceneAsync(Settings.CoreFrameWorkSettings.StartScene, LoadSceneMode.Additive);
#endif
        }
    }
}