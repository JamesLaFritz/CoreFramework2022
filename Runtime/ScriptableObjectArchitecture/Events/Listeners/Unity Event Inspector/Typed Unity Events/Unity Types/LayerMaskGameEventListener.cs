using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// The layer mask game event listener class
    /// </summary>
    /// <seealso cref="UnityGameEventListener{LayerMask, LayerMaskGameEvent, LayerMaskUnityEvent}"/>
    [AddComponentMenu(Utility.EventListenerSubmenu + "Layer Mask Event Listener")]
    public sealed class LayerMaskGameEventListener : UnityGameEventListener<LayerMask, LayerMaskGameEvent, LayerMaskUnityEvent> { }
}