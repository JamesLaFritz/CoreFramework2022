using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The double Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Double, DoubleGameEvent}"/>
    [CreateAssetMenu(fileName = "DoubleVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "Double",
                     order = Utility.AssetMenuOrderVariables + 17)]
    public class DoubleVariable : BaseVariable<double, DoubleGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = double.MinValue;
            maxValue = double.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<double>

        /// <inheritdoc />
        protected override double ClampValue(double value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(DoubleVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator float(DoubleVariable variable)
        {
            return (float) variable.Value;
        }

        public static implicit operator int(DoubleVariable variable)
        {
            return (int) variable.Value;
        }

        public static implicit operator long(DoubleVariable variable)
        {
            return (long) variable.Value;
        }

        public static implicit operator sbyte(DoubleVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(DoubleVariable variable)
        {
            return (short) variable.Value;
        }

        public static implicit operator uint(DoubleVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ulong(DoubleVariable variable)
        {
            return (ulong) variable.Value;
        }

        public static implicit operator ushort(DoubleVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}