using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The vector Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Vector2, Vector2Variable, Vector2GameEvent, Vector2UnityEvent}"/>
    [Serializable]
    public sealed class Vector2Reference : BaseReference<Vector2, Vector2Variable, Vector2GameEvent, Vector2UnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Reference"/> class
        /// </summary>
        public Vector2Reference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Reference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public Vector2Reference(Vector2 value) : base(value) { }
    }
}