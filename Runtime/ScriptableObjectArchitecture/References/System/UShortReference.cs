using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The short Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{UInt16, UShortVariable, UShortGameEvent, UShortUnityEvent}"/>
    [Serializable]
    public sealed class UShortReference : BaseReference<ushort, UShortVariable, UShortGameEvent, UShortUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UShortReference"/> class
        /// </summary>
        public UShortReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UShortReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public UShortReference(ushort value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(UShortReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(UShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(UShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(UShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator long(UShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator sbyte(UShortReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(UShortReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(UShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator ulong(UShortReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        #endregion
    }
}