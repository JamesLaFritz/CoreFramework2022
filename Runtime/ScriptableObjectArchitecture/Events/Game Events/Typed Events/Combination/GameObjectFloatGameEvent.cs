using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// A Game Event that has a Game Object and Float as arguments.
    /// </summary>
    [CreateAssetMenu(
        fileName = "GameObjectFloatGameEvent.asset",
        menuName = Utility.GameEvent + "GameObject Float")]
    public sealed class GameObjectFloatGameEvent : BaseGameEvent<GameObject, float>{ }
}