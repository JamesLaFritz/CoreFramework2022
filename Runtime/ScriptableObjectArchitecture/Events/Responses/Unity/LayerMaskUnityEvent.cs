using System;
using UnityEngine;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The layer mask unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [Serializable]
    public sealed class LayerMaskUnityEvent : UnityEvent<LayerMask> { }
}