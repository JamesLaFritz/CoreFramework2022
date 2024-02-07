using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Vector4 Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Vector4, Vector4Variable, Vector4GameEvent, Vector4UnityEvent}"/>
    [Serializable]
    public sealed class Vector4Reference : BaseReference<Vector4, Vector4Variable, Vector4GameEvent, Vector4UnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4Reference"/> class
        /// </summary>
        public Vector4Reference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4Reference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public Vector4Reference(Vector4 value) : base(value) { }
    }
}