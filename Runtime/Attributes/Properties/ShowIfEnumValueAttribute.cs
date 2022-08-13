// ShowIfEnumValueAttribute.cs
// 07-20-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Attributes.Properties
{
    /// <summary>
    /// Show/Hide a field based on a enum value in the same script.
    /// Order of attribute is important.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public class ShowIfEnumValueAttribute : PropertyAttribute
    {
        /// <summary>
        /// The name of the serialized enum property to use.
        /// </summary>
        public readonly string enumName;

        /// <summary>
        /// The index of the enum that controls the showing of this property.
        /// </summary>
        public readonly int enumIndex;

        /// <summary>
        /// Show if the enum value matches or not.
        /// </summary>
        public readonly bool show;

        /// <summary>
        /// Show/Hide a field based on a bool value in the same script.
        /// </summary>
        /// <param name="enumName">The name of the serialized enum property to use.</param>
        /// <param name="enumIndex">The index of the enum that controls the showing of this property.</param>
        /// <param name="show"> Show if the enum value matches or not. Defaults to true</param>
        /// <example>
        /// <code>
        /// public enum SomeEnum
        /// {
        ///     one,
        ///     two,
        ///     three
        /// }
        /// 
        /// public SomeEnum someEnum = SomeEnum.one;
        /// 
        /// [ShowIfEnumValue("someEnum", (int) SomeEnum.one)]
        /// public int showIfSomeEnumOne;
        /// 
        /// [ShowIfEnumValue("someEnum", (int) SomeEnum.one, false)]
        /// public int showIfSomeEnumNotOne;
        /// </code>
        /// </example>
        public ShowIfEnumValueAttribute(string enumName, int enumIndex, bool show = true)
        {
            this.enumName = enumName;
            this.enumIndex = enumIndex;
            this.show = show;
        }
    }
}