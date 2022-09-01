#region Description

// BaseGameEvent.cs
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

using System.Collections.Generic;
using CoreFramework.Attributes;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// Base class for all Scriptable Object Architecture Game Event Assets.
    /// Implements <seealso cref="IGameEvent"/>
    /// </summary>
    [System.Serializable]
    public abstract class BaseGameEvent : BaseObject, IGameEvent
    {
        private readonly List<IGameEventListener> _listeners = new();

        #region Implementation of IGameEvent

        /// <inheritdoc />
        [Button(ButtonAttribute.ButtonMode.Play)]
        public virtual void Raise()
        {
            //Debug.Log($"Raising IGameEventListener on {name}");
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventRaised();
        }

        /// <inheritdoc />
        public void AddListener(IGameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        /// <inheritdoc />
        public void RemoveListener(IGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }

        /// <inheritdoc />
        public virtual void RemoveAll()
        {
            _listeners.RemoveRange(0, _listeners.Count);
        }

        #endregion
    }

    /// <summary>
    /// Base <see cref="ScriptableObject"/> class for all Scriptable Object Architecture Game Event Assets. That Takes One Type Parameter.
    /// Implements <seealso cref="IGameEvent{T}"/>.
    /// </summary>
    [System.Serializable]
    public abstract class BaseGameEvent<T> : BaseGameEvent, IGameEvent<T>
    {
        private readonly List<IGameEventListener<T>> _typedListeners = new();
        
        [SerializeField] private T debugValue;

        #region Implementation of IGameEvent<T>

        /// <inheritdoc />
        public void Raise(T value)
        {
            for (int i = _typedListeners.Count - 1; i >= 0; i--)
                _typedListeners[i].OnEventRaised(value);

            base.Raise();
        }

        /// <inheritdoc />
        public void AddListener(IGameEventListener<T> listener)
        {
            if (!_typedListeners.Contains(listener))
                _typedListeners.Add(listener);
        }

        /// <inheritdoc />
        public void RemoveListener(IGameEventListener<T> listener)
        {
            if (_typedListeners.Contains(listener))
                _typedListeners.Remove(listener);
        }

        #endregion

        #region Overrides of BaseGameEvent

        /// <inheritdoc />
        //[Button(ButtonAttribute.Mode.Play)]
        public override void Raise()
        {
            Raise(debugValue);
        }

        #endregion
    }
}