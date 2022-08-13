// HeaderAttribute.cs
// 07-19-2022
// James LaFritz

using UnityEngine;
using Header = CoreFramework.Attributes.Decorators.HeaderAttribute;

namespace CoreFramework.Attributes.Decorators
{
    /// <summary>
    /// Draws a Header in the Inspector that allows using custom text, an icon, a color and a textheight increase.
    /// <example>
    /// <code>
    /// //Header(string text, string iconPath, float[] colorElement, float textHeightIncrease = 1.5f)
    /// [Header("Health", "", new[] {1f, 1f, 1f})] public float health = 100;
    /// [Header("Health", "", new[] {0.5f, 0.5f, 0.5f}, 2f)] public float health1 = 100;
    /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", new[] {1f, 1f, 1f})] public float health2 = 100;
    /// [Header("", "", new[] {0f, 0f, 0f, 1f})] public float health3 = 100;
    /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", new[] {0.5f, 0.5f, 0.5f}, 2f)] public float health4 = 100;
    /// 
    /// //Header(string text, string iconPath, float textHeightIncrease = 1.5f)
    /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension")] public float health5 = 100;
    /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", 2f)] public float health6 = 100;
    ///
    /// //Header(string s, bool textOnly = true)
    /// [Header("Assets/PathToYourIcon/NameOfYourIconWithExtension", false)] public float health7 = 100;
    /// [Header("Health")] public float health8 = 100;
    ///
    /// //Header(string text, string iconPath, PresetColor presetColor, float textHeightIncrease = 1.5f)
    /// [Header("Health", "", HeaderAttribute.PresetColor.Green)] public float health9 = 100;
    /// [Header("", "", HeaderAttribute.PresetColor.Magenta, 0.5f)] public float health10 = 100;
    /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", HeaderAttribute.PresetColor.Cyan)] public float health11 = 100;
    /// [Header("", "Assets/PathToYourIcon/NameOfYourIconWithExtension", HeaderAttribute.PresetColor.Blue)] public float health12 = 100;
    /// </code>
    /// </example>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
    public class HeaderAttribute : PropertyAttribute
    {
        /// <summary>
        /// The icon path
        /// </summary>
        public readonly string iconPath;

        /// <summary>
        /// The icon path is null
        /// </summary>
        public readonly bool iconPathIsNull;

        /// <summary>
        /// The header
        /// </summary>
        public readonly string header;

        /// <summary>
        /// The header is null
        /// </summary>
        public readonly bool headerIsNull;

        /// <summary>
        /// The color
        /// </summary>
        public readonly Color? color;

        /// <summary>
        /// The color is null
        /// </summary>
        public readonly bool colorIsNull;

        /// <summary>
        /// The text height increase
        /// </summary>
        public readonly float textHeightIncrease = 1.5f;

        /// <summary>
        /// The use default font size
        /// </summary>
        public readonly bool useDefaultFontSize;

        /// <summary>
        /// The yellow
        /// </summary>
        private readonly Color[] m_colorPresets = new[]
        {
            Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.grey, Color.magenta, Color.red,
            Color.yellow
        };

        /// <summary>
        /// Available Colors by name that can be used.
        /// <list type="PresetColor"></list>
        /// <value>Black, Blue, Cyan, Gray, Green, Grey, Magenta, Red, Yellow</value>
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
        /// Draws a Header in the Inspector that allows using custom text, an icon, a color and a textheight increase.
        /// Defaults to a height increase of 1.5.
		/// Null Color will use Grey for the seperator and white for the Text
        /// <example>
        /// <code>
        /// [Header("Health", "", new[] {1f, 1f, 1f})] public float health = 100;
        /// [Header("Health", "", new[] {0.5f, 0.5f, 0.5f}, 2f)] public float health1 = 100;
        /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", new[] {1f, 1f, 1f})] public float health2 = 100;
        /// [Header("", "", new[] {0f, 0f, 0f, 1f})] public float health3 = 100;
        /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", new[] {0.5f, 0.5f, 0.5f}, 2f)] public float health4 = 100;
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="text">The label text to use for the header.</param>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="colorElement">
		/// The color to use for the label. Can be null.
		/// If null uses Grey for the seperator and White for the Text
		/// Needs at least three elements. <code>new[] {r, g, b}) || new[] {r, g, b, a})</code> 
		/// </param>
        /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
        public HeaderAttribute(string text, string iconPath, float[] colorElement, float textHeightIncrease = 1.5f)
        {
            header = text;
            headerIsNull = string.IsNullOrEmpty(header);
            useDefaultFontSize = this.textHeightIncrease.Equals(textHeightIncrease);
            this.iconPath = iconPath;
            iconPathIsNull = string.IsNullOrEmpty(iconPath);

            colorIsNull = colorElement == null || colorElement.Length < 3;
            if (!colorIsNull)
            {
                float r = colorElement[0];
                float g = colorElement[1];
                float b = colorElement[2];
                float a = colorElement.Length > 3 ? colorElement[3] : 255;
                color = new Color(r, g, b, a);
            }

            if (!useDefaultFontSize)
            {
                this.textHeightIncrease = textHeightIncrease;
            }
        }

        /// <summary>
        /// Draws a Header in the Inspector that allows using custom text, an icon and a textheight increase.
        /// Defaults to a height increase of 1.5f
        /// </summary>
        /// <param name="text">The label text to use for the header.</param>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
        /// 
        /// <example>
        /// <code>
        /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension")] public float health5 = 100;
        /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", 2f)] public float health6 = 100;
        /// </code>
        /// </example>
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
        /// <example>
        /// <code>
        /// [Header("Assets/PathToYourIcon/NameOfYourIconWithExtension", false)] public float health7 = 100;
        /// [Header("Health")] public float health8 = 100;
        /// </code>
        /// </example>
        public HeaderAttribute(string s, bool textOnly = true) : this(textOnly ? s : "", textOnly ? "" : s, null) { }

        /// <summary>
        /// Draws a Header in the Inspector that allows using custom text, an icon, a preset color and a textheight increase.
        /// Defaults to a height increase of 1.5.
        /// </summary>
        /// <param name="text">The label text to use for the header.</param>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="presetColor">Uses on of the <see cref="PresetColor"/></param>
        /// <param name="textHeightIncrease">The amount to increase the height of the text by (Min value of 1).</param>
        /// <example>
        /// <code>
        /// [Header("Health", "", HeaderAttribute.PresetColor.Green)] public float health9 = 100;
        /// [Header("", "", HeaderAttribute.PresetColor.Magenta, 0.5f)] public float health10 = 100;
        /// [Header("Health", "Assets/PathToYourIcon/NameOfYourIconWithExtension", HeaderAttribute.PresetColor.Cyan)] public float health11 = 100;
        /// [Header("", "Assets/PathToYourIcon/NameOfYourIconWithExtension", HeaderAttribute.PresetColor.Blue)] public float health12 = 100;
        /// </code>
        /// </example>
        public HeaderAttribute(string text, string iconPath, PresetColor presetColor, float textHeightIncrease = 1.5f) :
            this(text, iconPath, null, textHeightIncrease)
        {
            color = m_colorPresets?[(int)presetColor];
            colorIsNull = color == null;
        }
    }
}