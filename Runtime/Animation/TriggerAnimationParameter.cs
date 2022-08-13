// TriggerAnimationParameter.cs
// 07-21-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Animation
{
    /// <summary>
    /// A Trigger Animation Parameter
    /// <see cref="AnimationParameter"/>.
    /// </summary>
    [Serializable]
    public class TriggerAnimationParameter : AnimationParameter
    {
        /// <summary>
        /// Activates the selected trigger on the animator
        /// </summary>
        /// <param name="animator"></param>
        public void Set(Animator animator)
        {
            if (animator.isInitialized)
                animator.SetTrigger(Index);
        }
    }
}