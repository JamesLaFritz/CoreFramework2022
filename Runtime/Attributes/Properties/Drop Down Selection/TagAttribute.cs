// TagAttribute.cs
// 07-20-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes.Properties.DropDownSelection
{
    /// <summary>
    /// Displays a dropdown list of available Tags (must be used with a 'string' typed field).
    /// <example>
    /// <code>
    /// [Tag] public string targetTag;
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TagAttribute : PropertyAttribute { }
}