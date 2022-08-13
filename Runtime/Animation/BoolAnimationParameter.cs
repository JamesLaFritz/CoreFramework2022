// BoolAnimationParameter.cs
// 07-21-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Animation
{
    /// <summary>
    /// A Bool Animation Parameter
    /// <see cref="AnimationParameter"/>.
    /// </summary>
    [Serializable]
    public class BoolAnimationParameter : AnimationParameter
    {
        /// <summary>
        /// Sets the value of the selected parameter, based on value
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="value"></param>
        public void Set(Animator animator, bool value)
        {
            if (animator.isInitialized)
                animator.SetBool(Index, value);
        }
    }
}