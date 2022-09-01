using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The bool game event listener
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Bool Event Listener")]
    public sealed class BoolGameEventListener : UnityGameEventListener<bool, BoolGameEvent, BoolUnityEvent> { }
}