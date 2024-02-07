using UnityEngine;

namespace CoreFramework
{
    public class DebugMonoBehaviour : MonoBehaviour
    {
        [SerializeField] private bool showDebugInfo = true;
        
        protected void LogInfo(string message, string callingMethod, string callingBehaviour)
        {
            if (!showDebugInfo) return;
            Debug.Log($"<size=18><b><color=blue>{name}: <i>{callingBehaviour}</i></color></b>" +
                      $"-<i><color=brown>{callingMethod}</color></i>" +
                      $"- {message}</size>", gameObject);
        }
        
        protected void LogError(string message, string callingMethod, string callingBehaviour)
        {
            Debug.LogError($"<size=25><b><color=maroon>{name}: <i>{callingBehaviour}</i></color></b>" +
                           $"-<i><color=purple>{callingMethod}</color></i>" +
                           $"- <color=red>{message}</color></size>", gameObject);
        }
        
        protected void LogWarning(string message, string callingMethod, string callingBehaviour)
        {
            if (!showDebugInfo) return;
            
            Debug.LogWarning($"<size=20><b><color=orange>{name}: <i>{callingBehaviour}</i></color></b>" +
                             $"-<i><color=olive>{callingMethod}</color></i>" +
                             $"- <color=yellow>{message}</color></size>", gameObject);
        }
    }
}