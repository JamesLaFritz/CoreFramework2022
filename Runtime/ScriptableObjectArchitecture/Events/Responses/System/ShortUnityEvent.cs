using System;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The short unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [Serializable]
    public sealed class ShortUnityEvent : UnityEvent<short> { }
}