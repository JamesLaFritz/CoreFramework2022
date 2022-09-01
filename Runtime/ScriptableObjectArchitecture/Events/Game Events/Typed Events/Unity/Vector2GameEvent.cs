using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "Vector2GameEvent.asset",
        menuName = Utility.GameEventStructs + "Vector2",
        order = Utility.AssetMenuOrderEvents + 6)]
    public sealed class Vector2GameEvent : BaseGameEvent<Vector2> { }
}