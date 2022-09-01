using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The UInt Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{UInt32, UIntGameEvent}"/>
    [CreateAssetMenu(fileName = "UnsignedIntVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "UInt",
                     order = Utility.AssetMenuOrderVariables + 23)]
    public class UIntVariable : BaseVariable<uint, UIntGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = uint.MinValue;
            maxValue = uint.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<uint>

        /// <inheritdoc />
        protected override uint ClampValue(uint value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(UIntVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(UIntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(UIntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(UIntVariable variable)
        {
            return (int) variable.Value;
        }

        public static implicit operator long(UIntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator sbyte(UIntVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(UIntVariable variable)
        {
            return (short) variable.Value;
        }

        public static implicit operator ulong(UIntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator ushort(UIntVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}