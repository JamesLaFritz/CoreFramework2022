using UnityEngine;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The audio clip unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [System.Serializable]
    public sealed class AudioClipUnityEvent : UnityEvent<AudioClip> { }
}