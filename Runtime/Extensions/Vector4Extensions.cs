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
    }
}