using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The byte game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "SByte Event Listener")]
    public sealed class SByteGameEventListener : UnityGameEventListener<sbyte, SByteGameEvent, SByteUnityEvent> { }
}