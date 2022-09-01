using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The audio clip game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{TType,TEvent,TResponse}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Audio CliP Event Listener")]
    public sealed class AudioClipGameEventListener : UnityGameEventListener<AudioClip, AudioClipGameEvent, AudioClipUnityEvent> { }
}