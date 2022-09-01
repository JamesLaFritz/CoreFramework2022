using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "BoundsGameEvent.asset",
        menuName = Utility.GameEventStructs + "Bounds",
        order = Utility.AssetMenuOrderEvents + 10)]
    public sealed class BoundsGameEvent : BaseGameEvent<Bounds> { }
}