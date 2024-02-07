using CoreFramework.Attributes;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    // ToDo: Create an C# Event that utilizes ISerializationCallbackReceiver that can be used instead of Unity Event
    // https://github.com/Siccity/SerializableCallback

    /// <summary>
    /// The unity game event listener class
    /// </summary>
    /// <seealso cref="BaseMonoBehaviour"/>
    public abstract class UnityGameEventListener : BaseMonoBehaviour { }

    /// <summary>
    /// The unity game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener"/>
    /// <seealso cref="IGameEventListener"/>
    public abstract class UnityGameEventListener<TEvent, TResponse> : UnityGameEventListener, IGameEventListener
        where TEvent : class, IGameEvent where TResponse : UnityEvent
    {
        /// <summary>
        /// The game event
        /// </summary>
        [SerializeField] private TEvent gameEvent;

        /// <summary>
        /// The response
        /// </summary>
        [SerializeField] private TResponse response;

        /// <summary>
        /// Ons the enable
        /// </summary>
        private void OnEnable()
        {
            gameEvent?.AddListener(this);
        }

        /// <summary>
        /// Ons the disable
        /// </summary>
        private void OnDisable()
        {
            gameEvent?.RemoveListener(this);
        }

        #region Implementation of IGameEventListener

        /// <inheritdoc />
        [Button(ButtonAttribute.ButtonMode.Play)]
        public void OnEventRaised()
        {
            response?.Invoke();
        }

        #endregion
    }

    /// <summary>
    /// The unity game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener"/>
    /// <seealso cref="IGameEventListener{TType}"/>
    public abstract class
        UnityGameEventListener<TType, TEvent, TResponse> : UnityGameEventListener, IGameEventListener<TType>
        where TEvent : class, IGameEvent<TType> where TResponse : UnityEvent<TType>
    {
        /// <summary>
        /// The game event
        /// </summary>
        [SerializeField] private TEvent gameEvent;

        /// <summary>
        /// The response
        /// </summary>
        [SerializeField] private TResponse response;

        /// <summary>
        /// The debug value
        /// </summary>
        [SerializeField] private TType debugValue;

        /// <summary>
        /// Ons the enable
        /// </summary>
        private void OnEnable()
        {
            gameEvent?.AddListener(this);
        }

        /// <summary>
        /// Ons the disable
        /// </summary>
        private void OnDisable()
        {
            gameEvent?.RemoveListener(this);
        }

        #region Implementation of IGameEventListener<in TType>

        /// <inheritdoc />
        public void OnEventRaised(TType value)
        {
            response?.Invoke(value);
        }

        #endregion

        /// <summary>
        /// Ons the event raised
        /// </summary>
        [Button(ButtonAttribute.ButtonMode.Play)]
        [UsedImplicitly]
        protected void OnEventRaised() => response?.Invoke(debugValue);
    }
    
    public abstract class UnityGameEventListener<TType1, TType2, TEvent, TResponse> : UnityGameEventListener, IGameEventListener<TType1, TType2>
        where TEvent : class, IGameEvent<TType1, TType2> where TResponse : UnityEvent<TType1, TType2>
    {
        /// <summary>
        /// The game event
        /// </summary>
        [SerializeField] private TEvent gameEvent;

        /// <summary>
        /// The response
        /// </summary>
        [SerializeField] private TResponse response;

        /// <summary>
        /// The debug value
        /// </summary>
        [SerializeField] private TType1 debugValue1;

        /// <summary>
        /// The debug value
        /// </summary>
        [SerializeField] private TType2 debugValue2;

        /// <summary>
        /// Ons the enable
        /// </summary>
        private void OnEnable()
        {
            gameEvent?.AddListener(this);
        }

        /// <summary>
        /// Ons the disable
        /// </summary>
        private void OnDisable()
        {
            gameEvent?.RemoveListener(this);
        }

        #region Implementation of IGameEventListener<in TType>

        /// <inheritdoc />
        public void OnEventRaised(TType1 value1, TType2 value2)
        {
            response?.Invoke(value1, value2);
        }

        #endregion

        /// <summary>
        /// Ons the event raised
        /// </summary>
        [Button(ButtonAttribute.ButtonMode.Play)]
        [UsedImplicitly]
        protected void OnEventRaised() => response?.Invoke(debugValue1, debugValue2);
    }
}