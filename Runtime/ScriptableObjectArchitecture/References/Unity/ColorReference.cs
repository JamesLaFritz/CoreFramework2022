using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Color Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Color, ColorVariable, ColorGameEvent, ColorUnityEvent}"/>
    [Serializable]
    public sealed class ColorReference : BaseReference<Color, ColorVariable, ColorGameEvent, ColorUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorReference"/> class
        /// </summary>
        public ColorReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public ColorReference(Color value) : base(value) { }
    }
}