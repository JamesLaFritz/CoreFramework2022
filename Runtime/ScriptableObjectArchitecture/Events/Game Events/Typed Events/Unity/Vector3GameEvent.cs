using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "Vector3GameEvent.asset",
        menuName = Utility.GameEventStructs + "Vector3",
        order = Utility.AssetMenuOrderEvents + 7)]
    public sealed class Vector3GameEvent : BaseGameEvent<Vector3> { }
}