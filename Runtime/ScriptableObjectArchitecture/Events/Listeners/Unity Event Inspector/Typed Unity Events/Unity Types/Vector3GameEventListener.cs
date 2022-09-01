using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The vector3 game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{Vector3, Vector3GameEvent, Vector3UnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Vector3 Event Listener")]
    public sealed class Vector3GameEventListener : UnityGameEventListener<Vector3, Vector3GameEvent, Vector3UnityEvent> { }
}