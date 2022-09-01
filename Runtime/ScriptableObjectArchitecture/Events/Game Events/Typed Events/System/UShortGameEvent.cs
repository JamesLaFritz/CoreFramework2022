using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "UShortGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "UShort",
        order = Utility.AssetMenuOrderEvents + 25)]
    public sealed class UShortGameEvent : BaseGameEvent<ushort> { }
}