using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The int Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{UInt32, UIntVariable, UIntGameEvent, UIntUnityEvent}"/>
    [Serializable]
    public sealed class UIntReference : BaseReference<uint, UIntVariable, UIntGameEvent, UIntUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIntReference"/> class
        /// </summary>
        public UIntReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIntReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public UIntReference(uint value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(UIntReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(UIntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(UIntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(UIntReference variable)
        {
            return (int) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator long(UIntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator sbyte(UIntReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(UIntReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(UIntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator ushort(UIntReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}