// RequiredReference.cs
// 07-22-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Requires the field to be not null.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public class RequiredReferenceAttribute : PropertyAttribute { }
}