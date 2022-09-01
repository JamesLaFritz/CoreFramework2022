using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    namespace CoreFramework.ScriptableObjectArchitecture.UnityEventListeners
    {
        /// <summary>
        /// The vector4 game event listener class
        /// </summary>
        /// <seealso cref="UnityGameEventListener{Vector4, Vector4GameEvent, Vector4UnityEvent}"/>
        [AddComponentMenu(Utility.EventListenerSubmenu + "Vector4 Event Listener")]
        public sealed class Vector4GameEventListener : UnityGameEventListener<Vector4, Vector4GameEvent, Vector4UnityEvent> { }
    }
}