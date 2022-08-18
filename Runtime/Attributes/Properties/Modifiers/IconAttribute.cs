// IconAttribute.cs
// 07-22-2022
// James LaFritz

using System;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Use this attribute to make a field have an icon in the label.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IconAttribute : Attribute
    {
        /// <summary>
        /// A project-relative path to a texture.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// <value>Create an IconAttribute with a path to an icon.</value>
        /// </summary>
        /// <param name="path">A project-relative path to a texture.</param>
        public IconAttribute(string path) => Path = path;
    }
}