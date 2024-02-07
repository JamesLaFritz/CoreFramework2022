using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The long Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Int64, LongVariable, LongGameEvent, LongUnityEvent}"/>
    [Serializable]
    public sealed class LongReference : BaseReference<long, LongVariable, LongGameEvent, LongUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongReference"/> class
        /// </summary>
        public LongReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public LongReference(long value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(LongReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(LongReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(LongReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator int(LongReference variable)
        {
            return (int) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator sbyte(LongReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(LongReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(LongReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(LongReference variable)
        {
            return (ulong) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(LongReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}