using System;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The coded game event listener class
    /// </summary>
    /// <seealso cref="IGameEventListener"/>
    [Serializable]
    public class CodedGameEventListener : IGameEventListener
    {
        /// <summary>
        /// The event
        /// </summary>
        [SerializeField] private GameEvent @event;
        
        /// <summary>
        /// The on response
        /// </summary>
        private Action _onResponse;

        /// <summary>
        /// Enables the response
        /// </summary>
        /// <param name="response">The response</param>
        public void Enable(Action response)
        {
            if (@event != null) @event.AddListener(this);
            _onResponse = response;
        }

        /// <summary>
        /// Disables this instance
        /// </summary>
        public void Disable()
        {
            if (@event != null) @event.RemoveListener(this);
            _onResponse = null;
        }

        #region Implementation of IGameEventListener

        /// <inheritdoc />
        public void OnEventRaised()
        {
            _onResponse?.Invoke();
        }

        #endregion
    }

    /// <summary>
    /// The coded game event listener class
    /// </summary>
    /// <seealso cref="CodedGameEventListener"/>
    /// <seealso cref="IGameEventListener{T}"/>
    [Serializable]
    public class CodedGameEventListener<T> : IGameEventListener<T>
    {
        /// <summary>
        /// The typed game event
        /// </summary>
        [SerializeField] private BaseGameEvent<T> typedGameEvent;

        /// <summary>
        /// The typed on response
        /// </summary>
        private Action<T> _typedOnResponse;

        /// <summary>
        /// Enables the response
        /// </summary>
        /// <param name="response">The response</param>
        public void Enable(Action<T> response)
        {
            if (typedGameEvent != null) typedGameEvent.AddListener(this);
            _typedOnResponse = response;
        }
        
        /// <summary>
        /// Disables this instance
        /// </summary>
        public void Disable()
        {
            if (typedGameEvent != null) typedGameEvent.RemoveListener(this);
            _typedOnResponse = null;
        }

        #region Implementation of IGameEventListener<in T>

        /// <inheritdoc />
        public void OnEventRaised(T value)
        {
            _typedOnResponse?.Invoke(value);
        }

        #endregion
    }
    
    /// <summary>
    /// The coded game event listener class
    /// </summary>
    /// <seealso cref="CodedGameEventListener"/>
    /// <seealso cref="IGameEventListener{T}"/>
    [Serializable]
    public class CodedGameEventListener<T1, T2> : IGameEventListener<T1, T2>
    {
        /// <summary>
        /// The typed game event
        /// </summary>
        [SerializeField] private BaseGameEvent<T1, T2> typedGameEvent;

        /// <summary>
        /// The typed on response
        /// </summary>
        private Action<T1, T2> _typedOnResponse;

        /// <summary>
        /// Enables the response
        /// </summary>
        /// <param name="response">The response</param>
        public void Enable(Action<T1, T2> response)
        {
            if (typedGameEvent != null) typedGameEvent.AddListener(this);
            _typedOnResponse = response;
        }

        /// <summary>
        /// Disables this instance
        /// </summary>
        public void Disable()
        {
            if (typedGameEvent != null) typedGameEvent.RemoveListener(this);
            _typedOnResponse = null;
        }

        #region Implementation of IGameEventListener<in T, in T2>

        /// <inheritdoc />
        public void OnEventRaised(T1 value1, T2 value2)
        {
            _typedOnResponse?.Invoke(value1, value2);
        }

        #endregion
    }
}