using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The color game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{Color, ColorGameEvent, ColorUnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Color Event Listener")]
    public sealed class ColorGameEventListener : UnityGameEventListener<Color, ColorGameEvent, ColorUnityEvent> { }
}