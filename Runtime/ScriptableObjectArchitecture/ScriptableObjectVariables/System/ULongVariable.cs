using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The ULong Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{UInt64, ULongGameEvent}"/>
    [CreateAssetMenu(fileName = "UnsignedLongVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "ULong",
                     order = Utility.AssetMenuOrderVariables + 24)]
    public class ULongVariable : BaseVariable<ulong, ULongGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = ulong.MinValue;
            maxValue = ulong.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<ulong>

        /// <inheritdoc />
        protected override ulong ClampValue(ulong value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(ULongVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(ULongVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(ULongVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(ULongVariable variable)
        {
            return (int) variable.Value;
        }

        public static implicit operator long(ULongVariable variable)
        {
            return (long) variable.Value;
        }

        public static implicit operator sbyte(ULongVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator uint(ULongVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ushort(ULongVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}