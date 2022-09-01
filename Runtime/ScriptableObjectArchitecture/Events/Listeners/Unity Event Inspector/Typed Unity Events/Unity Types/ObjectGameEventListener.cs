using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The object game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{Object, ObjectGameEvent, ObjectUnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Object Event Listener")]
    public sealed class ObjectGameEventListener : UnityGameEventListener<Object, ObjectGameEvent, ObjectUnityEvent> { }
}