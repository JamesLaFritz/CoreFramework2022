#region Description

// IGameEventListener.cs
// 09-21-2021
// James LaFritz

#endregion

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// Interface to Implement for an Object to listen to <see cref="IGameEvent"/>
    /// </summary>
    public interface IGameEventListener
    {
        /// <summary>
        /// Ons the event raised
        /// </summary>
        void OnEventRaised();
    }

    /// <summary>
    /// Interface to Implement for an Object to listen to <see cref="IGameEvent{T}"/> that takes one parameter.
    /// </summary>
    public interface IGameEventListener<in T>
    {
        /// <summary>
        /// Ons the event raised using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        void OnEventRaised(T value);
    }
}