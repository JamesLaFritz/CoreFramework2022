using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Color32 Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Color32, Color32Variable, Color32GameEvent, Color32UnityEvent}"/>
    [Serializable]
    public sealed class Color32Reference : BaseReference<Color32, Color32Variable, Color32GameEvent, Color32UnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Color32Reference"/> class
        /// </summary>
        public Color32Reference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color32Reference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public Color32Reference(Color32 value) : base(value) { }
    }
}