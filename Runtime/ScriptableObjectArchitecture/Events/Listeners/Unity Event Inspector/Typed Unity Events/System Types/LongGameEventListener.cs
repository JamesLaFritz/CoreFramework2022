using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The long game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Long Event Listener")]
    public sealed class LongGameEventListener : UnityGameEventListener<long, LongGameEvent, LongUnityEvent> { }
}