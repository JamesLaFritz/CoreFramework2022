// Vector4Extensions.cs
// 07-19-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Extension methods for <a href="https://docs.unity3d.com/ScriptReference/Vector4.html">Vector4</a>.
    /// </summary>
    public static class Vector4Extensions
    {
        /// <summary>
        /// Returns a <a href="https://docs.unity3d.com/ScriptReference/Quaternion.html">Quaternion</a>
        /// instance where the component values are equal to this
        /// <a href="https://docs.unity3d.com/ScriptReference/Vector4.html">Vector4</a>'s components.
        /// </summary>
        public static Quaternion ToQuaternion(this Vector4 vector4)
        {
            return new Quaternion(vector4.x, vector4.y, vector4.z, vector4.w);
        }

        /// <summary>
        /// Creates a new Vector4 with optionally overridden x, y, z, and/or w values.
        /// </summary>
        /// <param name="vector">The original Vector4 this method extends.</param>
        /// <param name="x">The new x value, or null to keep the original x value.</param>
        /// <param name="y">The new y value, or null to keep the original y value.</param>
        /// <param name="z">The new z value, or null to keep the original z value.</param>
        /// <param name="w">The new w value, or null to keep the original w value.</param>
        /// <returns>A new Vector4 with the x, y, z, and/or w values optionally replaced by the specified values.</returns>
        public static Vector4 With(this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            return new Vector4(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);
        }

        /// <summary>
        /// Creates a new Vector4 by adding the specified x, y, z, and/or w values to the original Vector4.
        /// </summary>
        /// <param name="vector">The original Vector4 this method extends.</param>
        /// <param name="x">The value to add to the x component, or null to leave the x value unchanged.</param>
        /// <param name="y">The value to add to the y component, or null to leave the y value unchanged.</param>
        /// <param name="z">The value to add to the z component, or null to leave the z value unchanged.</param>
        /// <param name="w">The value to add to the w component, or null to leave the w value unchanged.</param>
        /// <returns>A new Vector4 with the x, y, z, and/or w values incremented by the specified values.</returns>
        public static Vector4 Add(this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            return new Vector4(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0), vector.w + (w ?? 0));
        }
        
        /// <summary>
        /// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
        /// </summary>
        /// <param name="current">The current Vector4 position</param>
        /// <param name="target">The Vector4 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
        public static bool InRangeOf(this Vector4 current, Vector4 target, float range) =>
            (current - target).sqrMagnitude <= range * range;
    }
}