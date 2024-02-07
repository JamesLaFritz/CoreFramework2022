using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Vector3 Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Vector3, Vector3Variable, Vector3GameEvent, Vector3UnityEvent}"/>
    [Serializable]
    public sealed class Vector3Reference : BaseReference<Vector3, Vector3Variable, Vector3GameEvent, Vector3UnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3Reference"/> class
        /// </summary>
        public Vector3Reference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3Reference"/> class
        /// </summary>
        /// <param name="value">The value.</param>
        public Vector3Reference(Vector3 value) : base(value) { }
    }
}