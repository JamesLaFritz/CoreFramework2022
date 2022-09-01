using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The bounds game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Bounds Event Listener")]
    public sealed class BoundsGameEventListener : UnityGameEventListener<Bounds, BoundsGameEvent, BoundsUnityEvent> { }
}