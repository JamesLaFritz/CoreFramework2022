// HeaderAttribute.cs
// 07-19-2022
// James LaFritz

using System;
using UnityEngine;

namespace CoreFramework.Attributes
{
    /// <summary>
    /// Draws a Header in the Inspector that allows using custom text, an icon, a color and a text height increase.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HeaderAttribute : PropertyAttribute
    {
        /// <summary>
        /// The path to the icon. Relative to the Assets folder.
        /// </summary>
        public readonly string IconPath;

        /// <summary>
        /// The icon path is null
        /// </summary>
        public readonly bool IconPathIsNull;

        /// <summary>
        /// The header
        /// </summary>
        public readonly string Header;

        /// <summary>
        /// The header is null
        /// </summary>
        public readonly bool HeaderIsNull;

        /// <summary>
        /// The color
        /// </summary>
        public readonly Color? Color;

        /// <summary>
        /// The color is null
        /// </summary>
        public readonly bool ColorIsNull;

        /// <summary>
        /// The text height increase
        /// </summary>
        public readonly float TextHeightIncrease = 1.5f;

        /// <summary>
        /// Preset Colors to use. 
        /// </summary>
        private readonly Color[] _mColorPresets = {
            UnityEngine.Color.black, UnityEngine.Color.blue, UnityEngine.Color.cyan, UnityEngine.Color.gray, UnityEngine.Color.green, UnityEngine.Color.grey, UnityEngine.Color.magenta, UnityEngine.Color.red,
            UnityEngine.Color.yellow
        };

        /// <summary>
        /// Available Colors by name that can be used.
        /// <list type="PresetColor"></list>
        /// </summary>
        public enum PresetColor
        {
            /// <summary>
            /// The black preset color
            /// </summary>
            Black,

            /// <summary>
            /// The blue preset color
            /// </summary>
            Blue,

            /// <summary>
            /// The cyan preset color
            /// </summary>
            Cyan,

            /// <summary>
            /// The gray preset color
            /// </summary>
            Gray,

            /// <summary>
            /// The green preset color
            /// </summary>
            Green,

            /// <summary>
            /// The grey preset color
            /// </summary>
            Grey,

            /// <summary>
            /// The magenta preset color
            /// </summary>
            Magenta,

            /// <summary>
            /// The red preset color
            /// </summary>
            Red,

            /// <summary>
            /// The yellow preset color
            /// </summary>
            Yellow
        }

        /// <summary>
        /// Draws a Header in the Inspector that allows using custom text, an icon, a color and a text height increase.
        /// Defaults to a height increase of 1.5.
        /// Null Color will use Grey for the separator and white for the Text.
        /// </summary>
        /// <param name="text">The label text to use for the header.</param>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="colorElement">
        /// The color to use for the label. Can be null.
        /// If null uses Grey for the separator and White for the Text
        /// Needs at least three elements. <code>new[] {r, g, b}) || new[] {r, g, b, a})</code> 
        /// </param>
        /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
        public HeaderAttribute(string text, string iconPath, float[] colorElement, float textHeightIncrease = 1.5f)
        {
            Header = text;
            HeaderIsNull = string.IsNullOrEmpty(Header);
            var useDefaultFontSize = TextHeightIncrease.Equals(textHeightIncrease);
            IconPath = iconPath;
            IconPathIsNull = string.IsNullOrEmpty(iconPath);

            ColorIsNull = colorElement == null || colorElement.Length < 3;
            if (!ColorIsNull)
            {
                float r = colorElement![0];
                float g = colorElement[1];
                float b = colorElement[2];
                float a = colorElement.Length > 3 ? colorElement[3] : 255;
                Color = new Color(r, g, b, a);
            }

            if (!useDefaultFontSize)
            {
                TextHeightIncrease = textHeightIncrease;
            }
        }

        /// <summary>
        /// Draws a Header in the Inspector that allows using custom text, an icon and a text height increase.
        /// Defaults to a height increase of 1.5f
        /// </summary>
        /// <param name="text">The label text to use for the header.</param>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
        public HeaderAttribute(string text, string iconPath, float textHeightIncrease = 1.5f) :
            this(text, iconPath, null, textHeightIncrease) { }

        /// <summary>
        /// Draws a Header in the Inspector that allows using custom text or an icon with a textHeightIncrease of 1.5f
        /// </summary>
        /// <param name="s">
        /// If Text Only(textOnly == true), the text to use for the label of the header.
        /// If Icon Only(textOnly == false), the relative path (starting from 'Assets/') to the icon you want to display in front of the property.
        /// 
        /// </param>
        /// <param name="textOnly">Is this a text only (true) or icon only Header (false) defaults to true.</param>
        public HeaderAttribute(string s, bool textOnly = true) : this(textOnly ? s : "", textOnly ? "" : s, null) { }

        /// <summary>
        /// Draws a Header in the Inspector that allows using custom text, an icon, a preset color and a text height increase.
        /// Defaults to a height increase of 1.5.
        /// </summary>
        /// <param name="text">The label text to use for the header.</param>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="presetColor">Uses on of the <see cref="PresetColor"/></param>
        /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
        public HeaderAttribute(string text, string iconPath, PresetColor presetColor, float textHeightIncrease = 1.5f) :
            this(text, iconPath, null, textHeightIncrease)
        {
            Color = _mColorPresets?[(int)presetColor];
            ColorIsNull = Color == null;
        }
    }
}