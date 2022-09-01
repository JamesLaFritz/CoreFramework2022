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
        public virtual void Disable()
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
    public class CodedGameEventListener<T> : CodedGameEventListener, IGameEventListener<T>
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

        #region Overrides of CodedGameEventListener

        /// <inheritdoc />
        public override void Disable()
        {
            base.Disable();

            if (typedGameEvent != null) typedGameEvent.RemoveListener(this);
            _typedOnResponse = null;
        }

        #endregion

        #region Implementation of IGameEventListener<in T>

        /// <inheritdoc />
        public void OnEventRaised(T value)
        {
            _typedOnResponse?.Invoke(value);
        }

        #endregion
    }
}