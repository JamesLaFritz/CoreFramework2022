using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The byte Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{SByte, SByteVariable, SByteGameEvent, SByteUnityEvent}"/>
    [Serializable]
    public sealed class SByteReference : BaseReference<sbyte, SByteVariable, SByteGameEvent, SByteUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SByteReference"/> class
        /// </summary>
        public SByteReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SByteReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public SByteReference(sbyte value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(SByteReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(SByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(SByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(SByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator long(SByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator short(SByteReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator uint(SByteReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(SByteReference variable)
        {
            return (ulong) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(SByteReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}