using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Long Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Int64, LongGameEvent}"/>
    [CreateAssetMenu(fileName = "LongVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "Long",
                     order = Utility.AssetMenuOrderVariables + 18)]
    public class LongVariable : BaseVariable<long, LongGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = long.MinValue;
            maxValue = long.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<long>

        /// <inheritdoc />
        protected override long ClampValue(long value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(LongVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(LongVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(LongVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(LongVariable variable)
        {
            return (int) variable.Value;
        }

        public static implicit operator sbyte(LongVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(LongVariable variable)
        {
            return (short) variable.Value;
        }

        public static implicit operator uint(LongVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ulong(LongVariable variable)
        {
            return (ulong) variable.Value;
        }

        public static implicit operator ushort(LongVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}