using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The bool Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Boolean, BoolVariable, BoolGameEvent, BoolUnityEvent}"/>
    [Serializable]
    public sealed class BoolReference : BaseReference<bool, BoolVariable, BoolGameEvent, BoolUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoolReference"/> class
        /// </summary>
        public BoolReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public BoolReference(bool value) : base(value) { }
    }
}