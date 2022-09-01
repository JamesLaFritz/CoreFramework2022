using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Float Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Single, FloatGameEvent}"/>
    [CreateAssetMenu(fileName = "FloatVariable.asset", menuName = Utility.VariableSubmenu + "Float",
                     order = Utility.AssetMenuOrderVariables)]
    public class FloatVariable : BaseVariable<float, FloatGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = float.MinValue;
            maxValue = float.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<float>

        /// <inheritdoc />
        protected override float ClampValue(float value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator byte(FloatVariable variable)
        {
            return (byte) variable.Value;
        }

        public static implicit operator double(FloatVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(FloatVariable variable)
        {
            return (int) variable.Value;
        }

        public static implicit operator long(FloatVariable variable)
        {
            return (long) variable.Value;
        }

        public static implicit operator sbyte(FloatVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(FloatVariable variable)
        {
            return (short) variable.Value;
        }

        public static implicit operator uint(FloatVariable variable)
        {
            return (uint) variable.Value;
        }

        public static implicit operator ulong(FloatVariable variable)
        {
            return (ulong) variable.Value;
        }

        public static implicit operator ushort(FloatVariable variable)
        {
            return (ushort) variable.Value;
        }

        #endregion
    }
}