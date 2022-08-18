// ShowIfBoolAttribute.cs
// 07-20-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Show/Hide a field based on a bool value in the same script.
    /// Order of attribute is important.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public class ShowIfBoolAttribute : PropertyAttribute
    {
        /// <summary>
        /// The name of the serialized bool property to use.
        /// </summary>
        public readonly string boolName;

        /// <summary>
        /// The value of the bool property to show this property.
        /// show=true, the property will be shown when boolName is true and hidden when boolName is false.
        /// show=false, the property will be shown when boolName is false and hidden when boolName is true.
        /// </summary>
        public readonly bool show;

        /// <summary>
        /// Show/Hide a field based on a bool value in the same script.
        /// </summary>
        /// <param name="boolName">The name of the serialized bool property to use.</param>
        /// <param name="show"> The value of the bool to show this property. Defaults to true</param>
        public ShowIfBoolAttribute(string boolName, bool show = true)
        {
            this.boolName = boolName;
            this.show = show;
        }
    }
}