using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The string Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{String, StringVariable, StringGameEvent, StringUnityEvent}"/>
    [Serializable]
    public sealed class StringReference : BaseReference<string, StringVariable, StringGameEvent, StringUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringReference"/> class
        /// </summary>
        public StringReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public StringReference(string value) : base(value) { }
    }
}