// AnimationParameter.cs
// 07-21-2022
// James LaFritz
//
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147

using System;
using UnityEngine;

namespace CoreFramework.Animation
{
    /// <summary>
    /// From Bit Cake Studio's BitStrap
    /// https://assetstore.unity.com/publishers/4147
    /// Helps with optimization, caching the index of the parameter name for you automatically
    /// Helps with type-safe animation parameters
    /// Has a nice editor that allows you to choose a parameter from a dropdown menu in the inspector, based on the animator of the current object
    /// </summary>
    public abstract class AnimationParameter
    {
        public string name;

        [NonSerialized] private bool _cached;
        [NonSerialized] private int _index;

        public int Index
        {
            get
            {
                if (!_cached)
                {
                    _index = Animator.StringToHash(name);
                    _cached = true;
                }

                return _index;
            }
        }
    }
}