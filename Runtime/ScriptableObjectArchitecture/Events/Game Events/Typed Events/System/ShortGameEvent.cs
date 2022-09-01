using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "ShortGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "Short",
        order = Utility.AssetMenuOrderEvents + 20)]
    public sealed class ShortGameEvent : BaseGameEvent<short> { }
}