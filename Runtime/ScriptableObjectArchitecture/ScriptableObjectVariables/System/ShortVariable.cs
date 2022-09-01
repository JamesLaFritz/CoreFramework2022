using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Short Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Int16, ShortGameEvent}"/>
    [CreateAssetMenu(fileName = "ShortVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "Short",
                     order = Utility.AssetMenuOrderVariables + 20)]
    public class ShortVariable : BaseVariable<short, ShortGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = short.MinValue;
            maxValue = short.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<short>

        /// <inheritdoc />
        protected override short ClampValue(short value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(ShortVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(ShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(ShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(ShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator long(ShortVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator sbyte(ShortVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator uint(ShortVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ulong(ShortVariable variable)
        {
            return (ulong) variable.Value;
        }

        public static implicit operator ushort(ShortVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}