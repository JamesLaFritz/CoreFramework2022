using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
     /// <summary>
    /// The int Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Int32, IntVariable, IntGameEvent, IntUnityEvent}"/>
    [Serializable]
    public sealed class IntReference : BaseReference<int, IntVariable, IntGameEvent, IntUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntReference"/> class
        /// </summary>
        public IntReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public IntReference(int value) : base(value) { }

        #region Implicit Operator Overloading

        public static implicit operator byte(IntReference variable)
        {
            return (byte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator double(IntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator float(IntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator long(IntReference variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator sbyte(IntReference variable)
        {
            return (sbyte) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator short(IntReference variable)
        {
            return (short) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator uint(IntReference variable)
        {
            return (uint) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ulong(IntReference variable)
        {
            return (ulong) (variable.IsValueDefined ? variable.Value : default);
        }

        public static implicit operator ushort(IntReference variable)
        {
            return (ushort) (variable.IsValueDefined ? variable.Value : default);
        }

        #endregion
    }
}