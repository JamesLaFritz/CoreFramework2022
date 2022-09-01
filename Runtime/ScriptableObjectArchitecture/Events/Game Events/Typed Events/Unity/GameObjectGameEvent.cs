using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "GameObjectGameEvent.asset",
        menuName = Utility.GameEvent + "GameObject",
        order = Utility.AssetMenuOrderEvents + 4)]
    public sealed class GameObjectGameEvent : BaseGameEvent<GameObject> { }
}