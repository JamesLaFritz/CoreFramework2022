using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The short Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Int16, ShortVariable, ShortGameEvent, ShortUnityEvent}"/>
    [Serializable]
    public sealed class ShortReference : BaseReference<short, ShortVariable, ShortGameEvent, ShortUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortReference"/> class
        /// </summary>
        public ShortReference() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public ShortReference(short value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(ShortReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(ShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(ShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(ShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator long(ShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator sbyte(ShortReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(ShortReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(ShortReference variable)
        {
            return (ulong) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(ShortReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}