using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Layer Mask Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{LayerMask, LayerMaskVariable, LayerMaskGameEvent, LayerMaskUnityEvent}"/>
    [Serializable]
    public sealed class LayerMaskReference : BaseReference<LayerMask, LayerMaskVariable, LayerMaskGameEvent, LayerMaskUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayerMaskReference"/> class
        /// </summary>
        public LayerMaskReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayerMaskReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public LayerMaskReference(LayerMask value) : base(value) { }
    }
}