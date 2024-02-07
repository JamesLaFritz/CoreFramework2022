using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The game object Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{GameObject, GameObjectVariable, GameObjectGameEvent, GameObjectUnityEvent}"/>
    [Serializable]
    public sealed class GameObjectReference : BaseReference<GameObject, GameObjectVariable, GameObjectGameEvent, GameObjectUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectReference"/> class
        /// </summary>
        public GameObjectReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public GameObjectReference(GameObject value) : base(value) { }
    }
}