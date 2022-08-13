// IconAttribute.cs
// 07-22-2022
// James LaFritz

using System;

namespace CoreFramework.Attributes.Properties.Modifiers
{
    /// <summary>
    /// Use this attribute to make a field have an icon in the label.
    /// <example>
    /// <code>
    /// [Icon("Assets/Core/Demos/Attributes/Icons/Heart4Full.png")]
    /// public float Health;
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IconAttribute : Attribute
    {
        /// <summary>
        /// <value>A project-relative path to a texture.</value>
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// <value>Create an IconAttribute with a path to an icon.</value>
        /// </summary>
        /// <param name="path">A project-relative path to a texture.</param>
        public IconAttribute(string path) => Path = path;
    }
}