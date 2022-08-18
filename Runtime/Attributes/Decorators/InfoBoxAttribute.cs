// InfoBoxAttribute.cs
// 07-19-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// The info box type enum
    /// </summary>
    public enum InfoBoxType
    {
        /// <summary>
        /// The info info box type
        /// </summary>
        Info,

        /// <summary>
        /// The warning info box type
        /// </summary>
        Warning,

        /// <summary>
        /// The error info box type
        /// </summary>
        Error,

        /// <summary>
        /// The none info box type
        /// </summary>
        None
    }

    /// <summary>
    /// Draws an Info Box in the Inspector.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
    public class InfoBoxAttribute : PropertyAttribute
    {
        /// <summary>
        /// The text to display in the info box.
        /// </summary>
        public readonly string text;

        /// <summary>
        /// The info box type.
        /// </summary>
        public readonly InfoBoxType infoBoxType;

        /// <summary>
        /// Draws an Info Box in the Inspector.
        /// </summary>
        /// <param name="text">The message to display in the text box.</param>
        /// <param name="type">The type of message to display, defaults to Info.</param>
        public InfoBoxAttribute(string text, InfoBoxType type = InfoBoxType.Info)
        {
            this.text = text;
            infoBoxType = type;
        }
    }
}