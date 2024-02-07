#region Description

// IGameEvent.cs
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

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// Interface to Implement A Game Event.
    /// </summary>
    public interface IGameEvent
    {
        /// <summary>
        /// Raise the Event.
        /// </summary>
        void Raise();

        /// <summary>
        /// Add a <see cref="IGameEventListener"/> that gets notified when the event is raised.
        /// </summary>
        /// <param name="listener">The <see cref="IGameEventListener"/> to add.</param>
        void AddListener(IGameEventListener listener);

        /// <summary>
        /// Remove a <see cref="IGameEventListener"/> from the Event.
        /// </summary>
        /// <param name="listener">The <see cref="IGameEventListener"/> to remove.</param>
        void RemoveListener(IGameEventListener listener);

        /// <summary>
        /// Remove all Listeners from the game event.
        /// </summary>
        void RemoveAll();
    }

    /// <summary>
    /// Interface to Implement A Game Event That takes one parameter.
    /// </summary>
    /// <typeparam name="T">The Parameter type of the game event</typeparam>
    public interface IGameEvent<T>
    {
        /// <summary>
        /// Raise the Event.
        /// </summary>
        /// <param name="value">The value passed to the event raised.</param>
        void Raise(T value);

        /// <summary>
        /// Add a <see cref="IGameEventListener{T}"/> that gets notified when the event is raised.
        /// </summary>
        /// <param name="listener">The <see cref="IGameEventListener{T}"/> to add.</param>
        void AddListener(IGameEventListener<T> listener);

        /// <summary>
        /// Remove a <see cref="IGameEventListener{T}"/> from the Event.
        /// </summary>
        /// <param name="listener">The <see cref="IGameEventListener{T}"/> to remove.</param>
        void RemoveListener(IGameEventListener<T> listener);

        /// <summary>
        /// Remove all Listeners from the game event.
        /// </summary>
        void RemoveAll();
    }
    
    /// <summary>
    /// Interface to Implement A Game Event That takes one parameter.
    /// </summary>
    /// <typeparam name="T1">The Parameter type of the game event</typeparam>
    /// <typeparam name="T2">The Parameter type of the game event</typeparam>
    public interface IGameEvent<T1, T2>
    {
        /// <summary>
        /// Raise the Event.
        /// </summary>
        void Raise(T1 value1, T2 value2);

        /// <summary>
        /// Add a <see cref="IGameEventListener{T}"/> that gets notified when the event is raised.
        /// </summary>
        /// <param name="listener">The <see cref="IGameEventListener{T}"/> to add.</param>
        void AddListener(IGameEventListener<T1, T2> listener);

        /// <summary>
        /// Remove a <see cref="IGameEventListener{T}"/> from the Event.
        /// </summary>
        /// <param name="listener">The <see cref="IGameEventListener{T}"/> to remove.</param>
        void RemoveListener(IGameEventListener<T1, T2> listener);

        /// <summary>
        /// Remove all Listeners from the game event.
        /// </summary>
        void RemoveAll();
    }
}