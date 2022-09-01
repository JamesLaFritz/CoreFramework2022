using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The string game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "String Event Listener")]
    public sealed class StringGameEventListener : UnityGameEventListener<string, StringGameEvent, StringUnityEvent> { }
}