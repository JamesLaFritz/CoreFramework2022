using System;
using UnityEngine;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The color unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [Serializable]
    public sealed class ColorUnityEvent : UnityEvent<Color> { }
}