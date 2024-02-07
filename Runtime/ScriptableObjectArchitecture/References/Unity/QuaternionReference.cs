using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Quaternion Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Quaternion, QuaternionVariable, QuaternionGameEvent, QuaternionUnityEvent}"/>
    [Serializable]
    public sealed class
        QuaternionReference : BaseReference<Quaternion, QuaternionVariable, QuaternionGameEvent, QuaternionUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuaternionReference"/> class
        /// </summary>
        public QuaternionReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuaternionReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public QuaternionReference(Quaternion value) : base(value)
        {
        }
    }
}