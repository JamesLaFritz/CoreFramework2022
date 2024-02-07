using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The long Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{UInt64, ULongVariable, ULongGameEvent, ULongUnityEvent}"/>
    [Serializable]
    public sealed class ULongReference : BaseReference<ulong, ULongVariable, ULongGameEvent, ULongUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ULongReference"/> class
        /// </summary>
        public ULongReference() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ULongReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public ULongReference(ulong value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(ULongReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(ULongReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(ULongReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(ULongReference variable)
        {
            return (int) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator long(ULongReference variable)
        {
            return (long) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator sbyte(ULongReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(ULongReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(ULongReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(ULongReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}