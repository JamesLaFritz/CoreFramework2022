using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// A Game Event that has a Game Object and Float as arguments.
    /// </summary>
    [CreateAssetMenu(
        fileName = "GameObjectBoolGameEvent.asset",
        menuName = Utility.GameEvent + "GameObject Bool")]
    public sealed class GameObjectBoolGameEvent : BaseGameEvent<GameObject, bool>{ }
}