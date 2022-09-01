using System;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The float unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [Serializable]
    public sealed class FloatUnityEvent : UnityEvent<float> { }
}