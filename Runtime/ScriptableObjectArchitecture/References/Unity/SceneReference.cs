using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The Scene Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{SceneInfo, SceneVariable, SceneGameEvent, SceneUnityEvent}"/>
    [Serializable]
    public sealed class SceneReference : BaseReference<SceneInfo, SceneVariable, SceneGameEvent, SceneUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneReference"/> class
        /// </summary>
        public SceneReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public SceneReference(SceneInfo value) : base(value) { }
    }
}