using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The quaternion game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{Quaternion, QuaternionGameEvent, QuaternionUnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Quaternion Event Listener")]
    public sealed class QuaternionGameEventListener : UnityGameEventListener<Quaternion, QuaternionGameEvent, QuaternionUnityEvent> { }
}