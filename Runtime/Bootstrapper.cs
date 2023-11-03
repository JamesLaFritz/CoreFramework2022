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

            if (SceneManager.loadedSceneCount == 1)
                SceneManager.LoadScene(Settings.CoreFrameWorkSettings.StartScene, LoadSceneMode.Additive);
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
#if UNITY_EDITOR
            var currentlyLoadedEditorScene = SceneManager.GetActiveScene();
#endif
        
            if (SceneManager.GetSceneByName(Settings.CoreFrameWorkSettings.BootScene).isLoaded != true)
                SceneManager.LoadScene(Settings.CoreFrameWorkSettings.BootScene);

#if UNITY_EDITOR
            if (currentlyLoadedEditorScene.IsValid())
                SceneManager.LoadSceneAsync(currentlyLoadedEditorScene.name, LoadSceneMode.Additive);
#else
        SceneManager.LoadSceneAsync(Settings.CoreFrameWorkSettings.StartScene, LoadSceneMode.Additive);
#endif
        }
    }
}