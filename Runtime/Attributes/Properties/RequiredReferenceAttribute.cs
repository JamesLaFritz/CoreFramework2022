// RequiredReference.cs
// 07-22-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Requires the field to be not null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RequiredReferenceAttribute : PropertyAttribute { }
}