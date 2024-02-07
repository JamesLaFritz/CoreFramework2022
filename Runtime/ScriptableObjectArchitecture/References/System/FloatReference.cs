# region Description

// 
// FloatReference.cs
// 09-21-2021
// James LaFritz
// 

// ----------------------------------------------------------------------------
// Based on
//
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

#endregion

using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The float Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Single, FloatVariable, FloatGameEvent, FloatUnityEvent}"/>
    [Serializable]
    public sealed class FloatReference : BaseReference<float, FloatVariable, FloatGameEvent, FloatUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloatReference"/> class
        /// </summary>
        public FloatReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public FloatReference(float value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(FloatReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(FloatReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(FloatReference variable)
        {
            return (int) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator long(FloatReference variable)
        {
            return (long) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator sbyte(FloatReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(FloatReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(FloatReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(FloatReference variable)
        {
            return (ulong) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(FloatReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}