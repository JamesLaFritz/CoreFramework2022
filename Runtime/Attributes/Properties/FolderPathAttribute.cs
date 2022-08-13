// FolderPathAttribute.cs
// 07-21-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Attributes.Properties
{
    /// <summary>
    /// Put this attribute above a string field
    /// It adds a folder button to the right, with which you can select a folder path as the string value.
    /// You can also pass a bool value to control whether the path should be relative to the project
    /// root folder (The parent folder of Assets and Project Settings)
    /// <example>
    /// <code>
    /// [ProjectPath(false)] public string absolutePath;
    /// [ProjectPath(true)] public string relativePath;
    /// </code>
    /// </example>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = true)]
    public class FolderPathAttribute : PropertyAttribute
    {
        public readonly bool pathRelativeToProject;

        /// <summary>
        /// Set path string relative to the project with a folder selection button
        /// </summary>
        public FolderPathAttribute() : this(true) { }

        /// <summary>
        /// Set path string with a folder selection button
        /// </summary>
        /// <param name="pathRelativeToProject">Path is absolute (false) or relative to the project (true)</param>
        public FolderPathAttribute(bool pathRelativeToProject)
        {
            this.pathRelativeToProject = pathRelativeToProject;
        }
    }
}