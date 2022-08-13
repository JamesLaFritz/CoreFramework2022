// AnimatorParameterAttribute.cs
// 07-21-2022
// James LaFritz

using System;

namespace CoreFramework.Animation
{
    /// <summary>
    /// Lets you use Animation Parameters even when it's MonoBehaviour does not have a sibling Animator component.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AnimatorParameterAttribute : Attribute
    {
        public string animatorParameterName;

        public AnimatorParameterAttribute(string parameterName)
        {
            animatorParameterName = parameterName;
        }
    }
}