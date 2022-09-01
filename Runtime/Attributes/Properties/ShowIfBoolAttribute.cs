// ShowIfBoolAttribute.cs
// 07-20-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Show/Hide a field based on a bool value in the same script.
    /// Order of attribute is important.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ShowIfBoolAttribute : PropertyAttribute
    {
        /// <summary>
        /// The name of the serialized bool property to use.
        /// </summary>
        public readonly string BoolName;

        /// <summary>
        /// The value of the bool property to show this property.
        /// show=true, the property will be shown when boolName is true and hidden when boolName is false.
        /// show=false, the property will be shown when boolName is false and hidden when boolName is true.
        /// </summary>
        public readonly bool Show;

        /// <summary>
        /// Show/Hide a field based on a bool value in the same script.
        /// </summary>
        /// <param name="boolName">The name of the serialized bool property to use.</param>
        /// <param name="show"> The value of the bool to show this property. Defaults to true</param>
        public ShowIfBoolAttribute(string boolName, bool show = true)
        {
            BoolName = boolName;
            Show = show;
        }
    }
}