using System;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The char unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [Serializable]
    public sealed class CharUnityEvent : UnityEvent<char> { }
}