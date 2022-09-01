using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The color 32 game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{Color32, Color32GameEvent, Color32UnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Color32 Event Listener")]
    public sealed class Color32GameEventListener : UnityGameEventListener<Color32, Color32GameEvent, Color32UnityEvent> { }
}