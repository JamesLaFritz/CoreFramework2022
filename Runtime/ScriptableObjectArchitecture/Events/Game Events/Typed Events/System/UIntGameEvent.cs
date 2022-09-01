using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "UIntGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "UInt",
        order = Utility.AssetMenuOrderEvents + 23)]
    public sealed class UIntGameEvent : BaseGameEvent<uint> { }
}