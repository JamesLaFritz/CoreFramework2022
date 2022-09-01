using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The double game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Double Event Listener")]
    public sealed class DoubleGameEventListener : UnityGameEventListener<double, DoubleGameEvent, DoubleUnityEvent> { }
}