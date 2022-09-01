// ShowIfEnumValueAttribute.cs
// 07-20-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Show/Hide a field based on a enum value in the same script.
    /// Order of attribute is important.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ShowIfEnumValueAttribute : PropertyAttribute
    {
        /// <summary>
        /// The name of the serialized enum property to use.
        /// </summary>
        public readonly string EnumName;

        /// <summary>
        /// The index of the enum that controls the showing of this property.
        /// </summary>
        public readonly int EnumIndex;

        /// <summary>
        /// Show if the enum value matches or not.
        /// </summary>
        public readonly bool Show;

        /// <summary>
        /// Show/Hide a field based on a bool value in the same script.
        /// </summary>
        /// <param name="enumName">The name of the serialized enum property to use.</param>
        /// <param name="enumIndex">The index of the enum that controls the showing of this property.</param>
        /// <param name="show"> Show if the enum value matches or not. Defaults to true</param>
        public ShowIfEnumValueAttribute(string enumName, int enumIndex, bool show = true)
        {
            EnumName = enumName;
            EnumIndex = enumIndex;
            Show = show;
        }
    }
}