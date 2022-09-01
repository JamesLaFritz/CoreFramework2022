using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The SByte Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{SByte, SByteGameEvent}"/>
    [CreateAssetMenu(fileName = "SByteVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "SByte",
                     order = Utility.AssetMenuOrderVariables + 22)]
    public class SByteVariable : BaseVariable<sbyte, SByteGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = sbyte.MinValue;
            maxValue = sbyte.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<sbyte>

        /// <inheritdoc />
        protected override sbyte ClampValue(sbyte value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(SByteVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(SByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(SByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(SByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator long(SByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator short(SByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator uint(SByteVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ulong(SByteVariable variable)
        {
            return (ulong) variable.Value;
        }

        public static implicit operator ushort(SByteVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}