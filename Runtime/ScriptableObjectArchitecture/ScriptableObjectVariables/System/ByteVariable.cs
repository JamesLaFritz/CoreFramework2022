using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Byte Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Byte, ByteGameEvent}"/>
    [CreateAssetMenu(fileName = "ByteVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "Byte",
                     order = Utility.AssetMenuOrderVariables + 21)]
    public class ByteVariable : BaseVariable<byte, ByteGameEvent>
    {
        /// <summary>
        /// Unity Method: Reset to default values.
        /// </summary>
        private void Reset()
        {
            minValue = byte.MinValue;
            maxValue = byte.MaxValue;
            clampable = true;
        }

        #region Overrides of BaseVariable<byte>

        /// <inheritdoc />
        protected override byte ClampValue(byte value) => value.CompareTo(MinClampValue) < 0 ? MinClampValue :
            value.CompareTo(MaxClampValue) > 0 ? MaxClampValue : value;

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator double(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator float(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator int(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator long(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator sbyte(ByteVariable variable)
        {
            return (sbyte) variable.Value;
        }

        public static implicit operator short(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator uint(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator ulong(ByteVariable variable)
        {
            return variable.Value;
        }

        public static implicit operator ushort(ByteVariable variable)
        {
            return variable.Value;
        }

        #endregion
    }
}