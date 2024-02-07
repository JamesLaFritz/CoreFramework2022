using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Animation Curve Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{AnimationCurve, AnimationCurveVariable, AnimationCurveGameEvent, AnimationCurveUnityEvent}"/>
    [Serializable]
    public sealed class
        AnimationCurveReference : BaseReference<AnimationCurve, AnimationCurveVariable, AnimationCurveGameEvent, AnimationCurveUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationCurveReference"/> class
        /// </summary>
        public AnimationCurveReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationCurveReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public AnimationCurveReference(AnimationCurve value) : base(value) { }
    }
}