using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The int game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "UInt Event Listener")]
    public sealed class UIntGameEventListener : UnityGameEventListener<uint, UIntGameEvent, UIntUnityEvent> { }
}