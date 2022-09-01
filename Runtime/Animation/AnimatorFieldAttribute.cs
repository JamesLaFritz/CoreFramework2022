// AnimatorFieldAttribute.cs
// 07-21-2022
// James LaFritz
//
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147

using System;

namespace CoreFramework.Animation
{
    /// <summary>
    /// Lets you use AnimationParameters even when it's MonoBehaviour does not have a sibling Animator component.
    /// From Bit Cake Studio's BitStrap
    /// https://assetstore.unity.com/publishers/4147
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class AnimatorFieldAttribute : Attribute
    {
        public readonly string AnimatorFieldName;

        protected AnimatorFieldAttribute(string animatorFieldName)
        {
            AnimatorFieldName = animatorFieldName;
        }
    }
}