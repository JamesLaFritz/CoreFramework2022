using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The long game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "ULong Event Listener")]
    public sealed class ULongGameEventListener : UnityGameEventListener<ulong, ULongGameEvent, ULongUnityEvent> { }
}