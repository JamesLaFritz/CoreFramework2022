// ButtonAttribute.cs
// 07-19-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Add this attribute above one of your MonoBehaviour method and it will draw
    /// a button in the inspector that will run the method when clicked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        /// <summary>
        /// Determine which Unity Editor mode a button should work in.
        /// </summary>
        public enum ButtonMode
        {
            /// <summary>
            /// The button will only work in Editor mode (Unity Editor is not in Play Mode).
            /// </summary>
            Editor,

            /// <summary>
            /// The button will only work when Unity is in Play mode.
            /// </summary>
            Play,

            /// <summary>
            /// The button will work in both Editor and Play Mode
            /// </summary>
            Both
        }

        /// <summary>
        /// Which mode the button is clickable in the **_Inspector_** (Play Mode, Editor Mode, or Both).
        /// </summary>
        public readonly ButtonMode Mode;

        /// <summary>
        /// Initializes a new instance of the ButtonAttribute
        /// </summary>
        /// <param name="mode">The Unity Editor <see cref="ButtonMode"/> that the button should be clickable.</param>
        public ButtonAttribute(ButtonMode mode = ButtonMode.Both)
        {
            Debug.Assert(mode != ButtonMode.Both, "ButtonAttribute.Mode.Both is not a valid mode.");
            Mode = mode;
        }
    }
}