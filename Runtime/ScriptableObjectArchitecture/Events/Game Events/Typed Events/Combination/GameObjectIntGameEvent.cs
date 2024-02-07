using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// A Game Event that has a Game Object and Float as arguments.
    /// </summary>
    [CreateAssetMenu(
        fileName = "GameObjectFloatGameEvent.asset",
        menuName = Utility.GameEvent + "GameObject Int")]
    public sealed class GameObjectIntGameEvent : BaseGameEvent<GameObject, int>{ }
}