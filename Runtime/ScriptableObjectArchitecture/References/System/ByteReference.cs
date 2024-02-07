using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Byte Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Byte, ByteVariable, ByteGameEvent, ByteUnityEvent}"/>
    [Serializable]
    public sealed class ByteReference : BaseReference<byte, ByteVariable, ByteGameEvent, ByteUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ByteReference"/> class
        /// </summary>
        public ByteReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public ByteReference(byte value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator double(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator long(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator sbyte(ByteReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator uint(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator ulong(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator ushort(ByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        #endregion
    }
}