using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Int Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Int32, IntGameEvent}"/>
    [CreateAssetMenu(fileName = "IntVariable.asset", menuName = Utility.VariableSubmenu + "Int",
                     order = Utility.AssetMenuOrderVariables + 1)]
    public class IntVariable : BaseVariable<int, IntGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = int.MinValue;
            maxValue = int.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<int>

        /// <inheritdoc />
        protected override int ClampValue(int value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(IntVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(IntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(IntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator long(IntVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator sbyte(IntVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(IntVariable variable)
        {
            return (short) variable.Value;
        }

        public static implicit operator uint(IntVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ulong(IntVariable variable)
        {
            return (ulong) variable.Value;
        }

        public static implicit operator ushort(IntVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}