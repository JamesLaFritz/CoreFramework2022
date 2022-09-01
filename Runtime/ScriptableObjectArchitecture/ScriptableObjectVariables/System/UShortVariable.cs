using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The UShort Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{UInt16, UShortGameEvent}"/>
    [CreateAssetMenu(fileName = "UnsignedShortVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "UShort",
                     order = Utility.AssetMenuOrderVariables + 25)]
    public class UShortVariable : BaseVariable<ushort, UShortGameEvent>
    {
        /// <summary>
        /// Resets this instance
        /// </summary>
        private void Reset()
        {
            minValue = ushort.MinValue;
            maxValue = ushort.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<ushort>

        /// <inheritdoc />
        protected override ushort ClampValue(ushort value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(UShortVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(UShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(UShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(UShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator long(UShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator sbyte(UShortVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(UShortVariable variable)
        {
            return (short) variable.Value;
        }

        public static implicit operator ulong(UShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator ushort(UShortVariable variable)
        {
            return variable.Value;
        }

        #endregion
    }
}