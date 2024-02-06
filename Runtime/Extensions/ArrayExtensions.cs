#region Header
// ArrayExtensions.cs
// Author: James LaFritz
// Description: Bunch of utility extension methods to the Array class. Also, it contains some System.Linq like methods that does not generate garbage.
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147
#endregion

using CoreFramework.Functional;

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Bunch of utility extension methods to the Array class.
    /// Also, it contains some System.Linq like methods that does not generate garbage.
    /// <para></para>
    /// From Bit Cake Studio's BitStrap
    /// https://assetstore.unity.com/publishers/4147
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Behaves like System.Linq.FirstOrDefault however it does not generate garbage.
        /// </summary>
        public static Option<T> First<T>(this T[] collection)
        {
            return collection.Length > 0 ? new Option<T>(collection[0]) : default;
        }
    }
}