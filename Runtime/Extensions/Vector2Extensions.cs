#region Header
// Vector2Extensions.cs
// Author: James LaFritz
// Description: Provides extension methods for the <a hfref="https://docs.unity3d.com/ScriptReference/Vector2.html">UnityEngine.Vector2</a> struct.
#endregion

using UnityEngine;

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Provides extension methods for the <a hfref="https://docs.unity3d.com/ScriptReference/Vector2.html">UnityEngine.Vector2</a> struct.
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary>
        /// Creates a new Vector2 with optionally overridden x and/or y values.
        /// </summary>
        /// <param name="vector">The original Vector2 this method extends.</param>
        /// <param name="x">The new x value, or null to keep the original x value.</param>
        /// <param name="y">The new y value, or null to keep the original y value.</param>
        /// <returns>A new Vector2 with the x and/or y values optionally replaced by the specified values.</returns>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
        {
            return new Vector2(x ?? vector.x, y ?? vector.y);
        }

        /// <summary>
        /// Creates a new Vector2 by adding the specified x and/or y values to the original Vector2.
        /// </summary>
        /// <param name="vector">The original Vector2 this method extends.</param>
        /// <param name="x">The value to add to the x component, or null to leave the x value unchanged.</param>
        /// <param name="y">The value to add to the y component, or null to leave the y value unchanged.</param>
        /// <returns>A new Vector2 with the x and/or y values incremented by the specified values.</returns>
        public static Vector2 Add(this Vector2 vector, float? x = null, float? y = null)
        {
            return new Vector2(vector.x + (x ?? 0), vector.y + (y ?? 0));
        }
        
        /// <summary>
        /// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
        /// </summary>
        /// <param name="current">The current Vector2 position</param>
        /// <param name="target">The Vector2 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
        public static bool InRangeOf(this Vector2 current, Vector2 target, float range) =>
            (current - target).sqrMagnitude <= range * range;
    }
}