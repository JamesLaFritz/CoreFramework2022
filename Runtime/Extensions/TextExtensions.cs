#region Header
// TextExtensions.cs
// Author: James LaFritz
// Description: Extension methods for text manipulation.
// Code From Indie Wafflus Found at https://pastebin.com/qSVNV0k7
#endregion

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Extension methods for text manipulation.
    /// Code From Indie Wafflus
    /// Found at https://pastebin.com/qSVNV0k7
    /// </summary>
    public static class TextExtensions
    {
        /// <summary>
        /// Determines if the character is a white space character.
        /// Based on
        /// StackOverflow Thread Efficient way to remove ALL whitespace from String: https://stackoverflow.com/a/37347881
        /// and
        /// StackOverflow Thread How do I remove all non alphanumeric characters from a string except dash: https://stackoverflow.com/questions/3210393/how-do-i-remove-all-non-alphanumeric-characters-from-a-string-except-dash
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if the character is a white space character, otherwise false.</returns>
        public static bool IsWhitespace(this char character)
        {
            switch (character)
            {
                case '\u0020':
                case '\u00A0':
                case '\u1680':
                case '\u2000':
                case '\u2001':
                case '\u2002':
                case '\u2003':
                case '\u2004':
                case '\u2005':
                case '\u2006':
                case '\u2007':
                case '\u2008':
                case '\u2009':
                case '\u200A':
                case '\u202F':
                case '\u205F':
                case '\u3000':
                case '\u2028':
                case '\u2029':
                case '\u0009':
                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u000D':
                case '\u0085':
                {
                    return true;
                }

                default:
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Removes all white space characters from the given text.
        /// </summary>
        /// <param name="text">The text from which to remove white space characters.</param>
        /// <returns>The text with all white space characters removed.</returns>
        public static string RemoveWhitespaces(this string text)
        {
            int textLength = text.Length;
            char[] textCharacters = text.ToCharArray();
            int returnStringLength = 0;

            for (int charIndex = 0; charIndex < textLength; charIndex++)
            {
                char curChar = textCharacters[charIndex];

                if (curChar.IsWhitespace()) continue;

                textCharacters[returnStringLength++] = curChar;
            }

            return new string(textCharacters, 0, returnStringLength);
        }

        /// <summary>
        /// Removes all non alphanumeric characters from the given text.
        /// </summary>
        /// <param name="text">The text from which to remove non-alphanumeric characters.</param>
        /// <returns>The text with all non-alphanumeric characters removed.</returns>
        public static string RemoveSpecialCharacters(this string text)
        {
            int textLength = text.Length;
            char[] textCharacters = text.ToCharArray();
            int returnStringLength = 0;

            for (int charIndex = 0; charIndex < textLength; charIndex++)
            {
                char curChar = textCharacters[charIndex];

                if (!char.IsLetterOrDigit(curChar) && !curChar.IsWhitespace()) continue;

                textCharacters[returnStringLength++] = curChar;
            }

            return new string(textCharacters, 0, returnStringLength);
        }
    }
}