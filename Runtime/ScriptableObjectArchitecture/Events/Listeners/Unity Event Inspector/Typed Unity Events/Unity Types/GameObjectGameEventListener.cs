using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The game object game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{GameObject, GameObjectGameEvent, GameObjectUnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Game Object Event Listener")]
    public sealed class GameObjectGameEventListener : UnityGameEventListener<GameObject, GameObjectGameEvent, GameObjectUnityEvent> { }
}