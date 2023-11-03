using CoreFramework.Attributes;
using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// Base Class for all Scriptable Object Variables That have a type.
    /// Raises The Game Event when the value of the variable changes.
    /// </summary>
    /// <typeparam name="TType">The type that this variable is.</typeparam>
    /// <typeparam name="TEvent">The Game Event type to use.</typeparam>
    public abstract class BaseVariable<TType, TEvent> : BaseObject where TEvent : IGameEvent<TType>
    {
        /// <summary>
        /// Should this value be changeable during runtime? Will still be editable in the inspector regardless.
        /// </summary>
        [SerializeField] protected bool readOnly;

        /// <summary>
        /// Should a warning be raised if the value of this variable is changed.
        /// </summary>
        [SerializeField] [ShowIfBool("readOnly")]
        private bool raiseWarning = true;

        [Tooltip("Can the value of the variable be clamped.")] [SerializeField, HideInInspector]
        protected bool clampable;

        /// <summary>
        /// The value of this variable
        /// </summary>
        [SerializeField] private TType value;

        /// <summary>
        /// Is the value of the variable clamped
        /// </summary>
        [SerializeField] [ShowIfBool("clampable")]
        private bool isClamped;

        /// <summary>
        /// Is the value of the variable clamped
        /// </summary>
        private bool IsClamped => clampable && isClamped;

        /// <summary>
        /// The Min value of this variable. Only if this variable is clamped.
        /// </summary>
        [SerializeField] [ShowIfBool("isClamped")]
        protected TType minValue;

        /// <summary>
        /// The Max value of this variable. Only if this variable is clamped.
        /// </summary>
        [SerializeField] [ShowIfBool("isClamped")]
        protected TType maxValue;

        /// <summary>
        /// The Game Event to raise when the value of this variable changes.
        /// </summary>
        [SerializeField]
        protected TEvent onValueChangeGameEvent;

        /// <summary>
        /// The value of this variable. Raise the Game Event when the value is changed.
        /// </summary>
        public TType Value
        {
            get => value;

            set
            {
                TType oldValue = this.value;
                TType newValue = SetValue(value);

                if (newValue.Equals(oldValue)) return;

                this.value = newValue;
                onValueChangeGameEvent?.Raise(this.value);
            }
        }

        /// <summary>
        /// Gets the value of the min clamp value
        /// </summary>
        public TType MinClampValue => clampable ? minValue : default;

        /// <summary>
        /// Gets the value of the max clamp value
        /// </summary>
        public TType MaxClampValue => clampable ? maxValue : default;

        /// <summary>
        /// Sets the value using the specified value if it is not Read Only. If it is clamped will clamp the value.
        /// </summary>
        /// <param name="tValue">The value to set this to.</param>
        /// <returns>The local value.</returns>
        private TType SetValue(TType tValue)
        {
            if (!readOnly)
                return IsClamped ? ClampValue(tValue) : tValue;

            RaiseReadonlyWarning();
            return value;
        }

        /// <summary>
        /// Clamps the value using the specified value.
        /// </summary>
        /// <param name="tValue">The value to set to.</param>
        /// <returns>The clamped value.</returns>
        protected virtual TType ClampValue(TType tValue)
        {
            return tValue;
        }

        /// <summary>
        /// If the variable is read only and a warning should be raised. Logs a warning to the console.
        /// </summary>
        private void RaiseReadonlyWarning()
        {
            if (!readOnly && !raiseWarning)
                return;

            Debug.LogWarning("Tried to set value on " + name + ", but value is readonly!", this);
        }

        /// <summary>
        /// Creates a value from Variable Object.
        /// </summary>
        /// <param name="variable">The variable of the type that you want to get the value from.</param>
        /// <returns>The value of the variable.</returns>
        /// <example>
        /// <code>
        /// int count;
        /// IntVariable countVariable; // IntVariable is a BaseVariable of type int. public class IntVariable : BaseVariable{Int32}
        ///
        /// public void StartCounting()
        /// {
        ///     count = countVariable;
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// For more information on Implicit Operator Overloading see -
        /// https://www.codeproject.com/Articles/15191/Understanding-Implicit-Operator-Overloading-in-C
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
        /// </remarks>
        public static implicit operator TType(BaseVariable<TType, TEvent> variable)
        {
            return variable.Value;
        }

        public static implicit operator string(BaseVariable<TType, TEvent> variable)
        {
            return variable.ToString();
        }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            return value == null ? "null" : value.ToString();
        }

        #endregion
    }
}