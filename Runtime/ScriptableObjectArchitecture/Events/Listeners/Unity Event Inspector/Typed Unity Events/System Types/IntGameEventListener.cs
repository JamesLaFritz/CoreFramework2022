using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The int game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Int Event Listener")]
    public sealed class IntGameEventListener : UnityGameEventListener<int, IntGameEvent, IntUnityEvent> { }
}