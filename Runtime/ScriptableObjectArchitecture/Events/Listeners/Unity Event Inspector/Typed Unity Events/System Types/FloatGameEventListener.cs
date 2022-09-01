using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The float game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Float Event Listener")]
    public sealed class FloatGameEventListener : UnityGameEventListener<float, FloatGameEvent, FloatUnityEvent> { }
}