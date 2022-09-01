// QuaternionExtensions.cs
// 07-19-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Extension methods for <a href="https://docs.unity3d.com/ScriptReference/Quaternion.html">Quaternion</a>.
    /// </summary>
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Returns a <a href="https://docs.unity3d.com/ScriptReference/Vector4.html">Vector4</a>
        /// instance where the component values are equal to this
        /// <a href="https://docs.unity3d.com/ScriptReference/Quaternion.html">Quaternion</a>'s components.
        /// </summary>
        public static Vector4 ToVector4(this Quaternion quaternion)
        {
            return new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}