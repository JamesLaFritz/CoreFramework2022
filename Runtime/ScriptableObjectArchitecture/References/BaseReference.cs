#region Description

// BaseReference.cs
// 09-21-2021
// James LaFritz

// ----------------------------------------------------------------------------
// Based on
//
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

#endregion

using CoreFramework.Attributes;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// Base Class for all Reference Variables That have a type.
    /// Is a Game Event that gets raised if the variable changes.
    /// </summary>
    /// <typeparam name="TBase">The type that this variable is.</typeparam>
    /// <typeparam name="TVariable"><see cref="BaseVariable{TType,TEvent}"/></typeparam>
    /// <typeparam name="TEvent"><see cref="IGameEvent"/></typeparam>
    [System.Serializable]
    public class BaseReference<TBase, TVariable, TEvent>
        where TEvent : IGameEvent<TBase>
        where TVariable : BaseVariable<TBase, TEvent>
    {
        /// <summary>
        /// The Selection enum
        /// </summary>
        public enum Selection
        {
            /// <summary>
            /// The Scriptable Object Selection
            /// </summary>
            ScriptableObject,

            /// <summary>
            /// The Value Selection
            /// </summary>
            Value
        }

        /// <summary>
        /// The value.
        /// </summary>
        [SerializeField] protected Selection selection = Selection.Value;

        /// <summary>
        /// The constant value.
        /// </summary>
        [SerializeField] [ShowIfEnumValue("selection", (int) Selection.Value)]
        protected TBase constantValue;

        /// <summary>
        /// The change event.
        /// </summary>
        [SerializeField] [ShowIfEnumValue("selection", (int) Selection.Value)]
        protected TEvent onValueChangeGameEvent;

        /// <summary>
        /// The variable.
        /// </summary>
        [SerializeField]
        [ShowIfEnumValue("selection", (int) Selection.ScriptableObject)]
        protected TVariable variable;

        /// <summary>
        /// Gets or sets the value of the value.
        /// </summary>
        public virtual TBase Value
        {
            get => selection == Selection.Value ? constantValue : variable != null ? variable.Value : default;
            set
            {
                TBase oldValue = Value;
                TBase newValue;

                if (selection == Selection.ScriptableObject && variable != null)
                {
                    variable.Value = value;
                    newValue = variable.Value;
                }
                else
                {
                    selection = Selection.Value;
                    newValue = constantValue = value;
                }

                if (newValue != null && newValue.Equals(oldValue)) return;

                if (selection == Selection.Value)
                {
                    Raise();
                }
            }
        }

        /// <summary>
        /// Sets the initial value using the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetInitialValue(TBase value)
        {
            if (selection == Selection.ScriptableObject && variable != null)
            {
                variable.Value = value;
            }
            else
            {
                selection = Selection.Value;
                constantValue = value;
            }
        }

        /// <summary>
        /// Is the value defined.
        /// </summary>
        public bool IsValueDefined => selection == Selection.Value || variable != null;

        /// <summary>
        /// Raises this instance.
        /// </summary>
        [Button(ButtonAttribute.ButtonMode.Play)]
        protected void Raise()
        {
            Raise(Value);
        }

        /// <summary>
        /// Raises the value.
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual void Raise(TBase value)
        {
            onValueChangeGameEvent?.Raise(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReference{TBase,TVariable,TEvent}"/> class
        /// </summary>
        public BaseReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReference{TBase,TVariable,TEvent}"/> class
        /// </summary>
        /// <param name="baseValue">The base value</param>
        public BaseReference(TBase baseValue)
        {
            selection = Selection.Value;
            constantValue = baseValue;
        }

        /// <summary>
        /// Creates the copy
        /// </summary>
        /// <returns>The copy</returns>
        public BaseReference<TBase, TVariable, TEvent> CreateCopy()
        {
            BaseReference<TBase, TVariable, TEvent> copy =
                (BaseReference<TBase, TVariable, TEvent>) System.Activator.CreateInstance(GetType());
            copy.selection = selection;
            copy.constantValue = constantValue;
            copy.variable = variable;

            return copy;
        }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => IsValueDefined ? Value?.ToString() : "null";

        #endregion

        #region Implicit Operator Overloading

        /// <summary>
        /// Creates a value from Variable Object,
        /// </summary>
        /// <param name="variable">The variable pf the type that you want to get the value from.</param>
        /// <returns>The value of the variable.</returns>
        /// <example>
        /// <code>
        /// int count;
        /// IntVariable countVariable; // IntVariable is a BaseVariable of type int. public class IntVariable : BaseVariable{int, IntGameEvent}
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
        public static implicit operator TBase(BaseReference<TBase, TVariable, TEvent> variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator string(BaseReference<TBase, TVariable, TEvent> variable)
        {
            return variable.ToString();
        }

        public static implicit operator BaseReference<TBase, TVariable, TEvent>(TVariable variable)
        {
            BaseReference<TBase, TVariable, TEvent> reference = new BaseReference<TBase, TVariable, TEvent>
            {
                selection = Selection.ScriptableObject,
                variable = variable
            };

            return reference;
        }

        public static implicit operator BaseReference<TBase, TVariable, TEvent>(TBase value)
        {
            BaseReference<TBase, TVariable, TEvent> reference = new BaseReference<TBase, TVariable, TEvent>
            {
                constantValue = value
            };

            return reference;
        }

        #endregion
    }

    /// <summary>
    /// Base Class for all Reference Variables That have a type.
    /// Is a Game Event that gets raised if the variable changes.
    /// Also contains a Unity Event that gets raised if the value changes.
    /// This is the class that is used for all Reference Variables.
    /// </summary>
    /// <typeparam name="TBase">The type that this variable is.</typeparam>
    /// <typeparam name="TVariable"><see cref="BaseVariable{T, TEvent}"/></typeparam>
    /// <typeparam name="TEvent">The Game Event of variable type to use.</typeparam>
    /// <typeparam name="TUEvent">The Unity Event to use.</typeparam>
    [System.Serializable]
    public class BaseReference<TBase, TVariable, TEvent, TUEvent> : BaseReference<TBase, TVariable, TEvent>
        where TEvent : IGameEvent<TBase>
        where TVariable : BaseVariable<TBase, TEvent>
        where TUEvent : UnityEvent<TBase>
    {
        /// <summary>
        /// The change unity event
        /// </summary>
        [SerializeField] private TUEvent changeUnityEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReference{TBase,TVariable,TEvent,TUEvent}"/> class
        /// </summary>
        public BaseReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReference{TBase,TVariable,TEvent,TUEvent}"/> class
        /// </summary>
        /// <param name="baseValue">The base value</param>
        public BaseReference(TBase baseValue)
        {
            selection = Selection.Value;
            constantValue = baseValue;
        }

        #region Overrides of BaseReference<TBase,TVariable, TEvent>

        /// <inheritdoc />
        public override TBase Value
        {
            get => base.Value;
            set
            {
                TBase oldValue = Value;
                base.Value = value;

                if (selection == Selection.Value) return;

                TBase newValue = Value;
                if (newValue.Equals(oldValue)) return;

                changeUnityEvent?.Invoke(Value);
            }
        }

        /// <inheritdoc />
        protected override void Raise(TBase value)
        {
            base.Raise(value);
            changeUnityEvent?.Invoke(Value);
        }

        #endregion

        #region Implicit Operator Overloading

        public static implicit operator TBase(BaseReference<TBase, TVariable, TEvent, TUEvent> variable)
        {
            return variable.IsValueDefined ? variable.Value : default;
        }

        public static implicit operator string(BaseReference<TBase, TVariable, TEvent, TUEvent> variable)
        {
            return variable.IsValueDefined ? variable.ToString() : "null";
        }

        public static implicit operator BaseReference<TBase, TVariable, TEvent, TUEvent>(TVariable variable)
        {
            BaseReference<TBase, TVariable, TEvent, TUEvent> reference =
                new BaseReference<TBase, TVariable, TEvent, TUEvent>
                {
                    selection = Selection.ScriptableObject,
                    variable = variable
                };

            return reference;
        }

        public static implicit operator BaseReference<TBase, TVariable, TEvent, TUEvent>(TBase value)
        {
            BaseReference<TBase, TVariable, TEvent, TUEvent> reference =
                new BaseReference<TBase, TVariable, TEvent, TUEvent> {constantValue = value};

            return reference;
        }

        #endregion
    }
}