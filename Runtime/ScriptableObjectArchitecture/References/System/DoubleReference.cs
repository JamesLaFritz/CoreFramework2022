using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Double Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Double, DoubleVariable, DoubleGameEvent, DoubleUnityEvent}"/>
    [Serializable]
    public sealed class DoubleReference : BaseReference<double, DoubleVariable, DoubleGameEvent, DoubleUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleReference"/> class
        /// </summary>
        public DoubleReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public DoubleReference(double value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(DoubleReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(DoubleReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(DoubleReference variable)
        {
            return (float) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator int(DoubleReference variable)
        {
            return (int) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator long(DoubleReference variable)
        {
            return (long) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator sbyte(DoubleReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(DoubleReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(DoubleReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(DoubleReference variable)
        {
            return (ulong) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(DoubleReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}