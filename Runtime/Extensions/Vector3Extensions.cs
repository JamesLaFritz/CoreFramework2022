#region Header
// Vector3Extensions.cs
// Author: James LaFritz
// Description: Provides extension methods for the <a hfref="https://docs.unity3d.com/ScriptReference/Vector3.html">UnityEngine.Vector3</a> struct.
#endregion

using UnityEngine;

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Provides extension methods for the <a hfref="https://docs.unity3d.com/ScriptReference/Vector3.html">UnityEngine.Vector3</a> struct.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Creates a new Vector3 with optionally overridden x, y, and/or z values.
        /// </summary>
        /// <param name="vector">The original Vector3 this method extends.</param>
        /// <param name="x">The new x value, or null to keep the original x value.</param>
        /// <param name="y">The new y value, or null to keep the original y value.</param>
        /// <param name="z">The new z value, or null to keep the original z value.</param>
        /// <returns>A new Vector3 with the x, y, and/or z values optionally replaced by the specified values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Creates a new Vector3 by adding the specified x, y, and/or z values to the original Vector3.
        /// </summary>
        /// <param name="vector">The original Vector3 this method extends.</param>
        /// <param name="x">The value to add to the x component, or null to leave the x value unchanged.</param>
        /// <param name="y">The value to add to the y component, or null to leave the y value unchanged.</param>
        /// <param name="z">The value to add to the z component, or null to leave the z value unchanged.</param>
        /// <returns>A new Vector3 with the x, y, and/or z values incremented by the specified values.</returns>
        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
        }

        /// <summary>
        /// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
        /// </summary>
        /// <param name="current">The current Vector3 position</param>
        /// <param name="target">The Vector3 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
        public static bool InRangeOf(this Vector3 current, Vector3 target, float range) =>
            (current - target).sqrMagnitude <= range * range;
    }
}