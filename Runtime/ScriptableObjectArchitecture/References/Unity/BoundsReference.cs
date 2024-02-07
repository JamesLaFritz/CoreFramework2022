using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Bounds Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Bounds, BoundsVariable, BoundsGameEvent, BoundsUnityEvent}"/>
    [Serializable]
    public sealed class BoundsReference : BaseReference<Bounds, BoundsVariable, BoundsGameEvent, BoundsUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsReference"/> class
        /// </summary>
        public BoundsReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public BoundsReference(Bounds value) : base(value) { }
    }
}