using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "ULongGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "ULong",
        order = Utility.AssetMenuOrderEvents + 24)]
    public sealed class ULongGameEvent : BaseGameEvent<ulong> { }
}