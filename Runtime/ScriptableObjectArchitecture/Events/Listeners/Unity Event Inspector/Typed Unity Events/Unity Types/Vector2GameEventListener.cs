using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The Vector2 game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{Vector2, Vector2GameEvent, Vector2UnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Vector2 Event Listener")]
    public sealed class Vector2GameEventListener : UnityGameEventListener<Vector2, Vector2GameEvent, Vector2UnityEvent> { }
}