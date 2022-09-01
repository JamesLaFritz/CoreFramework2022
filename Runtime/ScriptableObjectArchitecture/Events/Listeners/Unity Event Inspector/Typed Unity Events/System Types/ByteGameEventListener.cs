using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The byte game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Byte Event Listener")]
    public sealed class ByteGameEventListener : UnityGameEventListener<byte, ByteGameEvent, ByteUnityEvent> { }
}