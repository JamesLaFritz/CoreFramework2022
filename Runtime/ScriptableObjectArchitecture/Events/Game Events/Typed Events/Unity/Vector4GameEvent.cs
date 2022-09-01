using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "Vector4GameEvent.asset",
        menuName = Utility.GameEventStructs + "Vector4",
        order = Utility.AssetMenuOrderEvents + 8)]
    public sealed class Vector4GameEvent : BaseGameEvent<Vector4> { }
}