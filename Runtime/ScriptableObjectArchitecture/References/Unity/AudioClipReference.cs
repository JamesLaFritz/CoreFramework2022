using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Audio Clip Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{AudioClip, AudioClipVariable, AudioClipGameEvent, AudioClipUnityEvent}"/>
    [Serializable]
    public sealed class AudioClipReference : BaseReference<AudioClip, AudioClipVariable, AudioClipGameEvent, AudioClipUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipReference"/> class
        /// </summary>
        public AudioClipReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public AudioClipReference(AudioClip value) : base(value) { }
    }
}