using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Char Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Char, CharVariable, CharGameEvent, CharUnityEvent}"/>
    [Serializable]
    public sealed class CharReference : BaseReference<char, CharVariable, CharGameEvent, CharUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharReference"/> class
        /// </summary>
        public CharReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public CharReference(char value) : base(value) { }
    }
}