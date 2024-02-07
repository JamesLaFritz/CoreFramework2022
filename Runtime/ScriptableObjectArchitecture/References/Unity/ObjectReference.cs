using System;
using CoreFramework.ScriptableObjectArchitecture.Events;
using CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables;
using Object = UnityEngine.Object;

namespace CoreFramework.ScriptableObjectArchitecture.References
{
    /// <summary>
    /// The object Variable Reference.
    /// </summary>
    /// <seealso cref="BaseReference{Object, ObjectVariable, ObjectGameEvent, ObjectUnityEvent}"/>
    [Serializable]
    public sealed class ObjectReference : BaseReference<Object, ObjectVariable, ObjectGameEvent, ObjectUnityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectReference"/> class
        /// </summary>
        public ObjectReference() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectReference"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public ObjectReference(Object value) : base(value) { }
    }
}