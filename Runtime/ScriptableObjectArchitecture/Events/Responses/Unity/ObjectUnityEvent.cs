using System;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The object unity event class
    /// </summary>
    /// <seealso cref="UnityEvent"/>
    [Serializable]
    public sealed class ObjectUnityEvent : UnityEvent<Object> { }
}