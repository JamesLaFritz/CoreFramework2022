using UnityEngine;
using UnityEngine.Events;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [AddComponentMenu(Utility.EventListenerSubmenu + "Game Event Listener")]
    public sealed class GameEventListener : UnityGameEventListener<BaseGameEvent, UnityEvent> { }
}