using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoreFramework
{
    public class Bootstrapper : MonoBehaviour
    {
        private async void Start()
        {
            Application.runInBackground = true;
            //await UnityServices.InitializeAsync();

            // Asynchronous initialization of services can be added here.
            // await UnityServices.InitializeAsync();
            
            if (Settings.CoreFrameWorkSettings.StartScene == null) return;

            // Load the start scene additively if it's the only scene currently loaded.
            if (SceneManager.loadedSceneCount == 1)
                SceneManager.LoadScene(Settings.CoreFrameWorkSettings.StartScene, LoadSceneMode.Additive);
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
#if UNITY_EDITOR
            var currentlyLoadedEditorScene = SceneManager.GetActiveScene();
#endif
            
            if (Settings.CoreFrameWorkSettings.BootScene == null) return;

            // Load the designated boot scene if it's not already loaded.
            if (SceneManager.GetSceneByName(Settings.CoreFrameWorkSettings.BootScene).isLoaded != true)
                SceneManager.LoadScene(Settings.CoreFrameWorkSettings.BootScene);

#if UNITY_EDITOR
            if (currentlyLoadedEditorScene.IsValid())
                SceneManager.LoadSceneAsync(currentlyLoadedEditorScene.name, LoadSceneMode.Additive);
#else
            if (Settings.CoreFrameWorkSettings.StartScene == null) return;
            // Load the start scene additively in a built game.
            SceneManager.LoadSceneAsync(Settings.CoreFrameWorkSettings.StartScene, LoadSceneMode.Additive);
#endif
        }
    }
}