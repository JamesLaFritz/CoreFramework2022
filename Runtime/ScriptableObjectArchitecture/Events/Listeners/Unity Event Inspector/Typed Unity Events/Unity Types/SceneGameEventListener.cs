using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The scene game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{SceneInfo, SceneGameEvent, SceneUnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Scene Event Listener")]
    public sealed class SceneGameEventListener : UnityGameEventListener<SceneInfo, SceneGameEvent, SceneUnityEvent> { }
}