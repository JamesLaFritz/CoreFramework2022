using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The short game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Short Event Listener")]
    public sealed class ShortGameEventListener : UnityGameEventListener<short, ShortGameEvent, ShortUnityEvent> { }
}