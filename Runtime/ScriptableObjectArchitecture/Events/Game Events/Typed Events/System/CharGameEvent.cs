using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "CharGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "Char",
        order = Utility.AssetMenuOrderEvents + 19)]
    public sealed class CharGameEvent : BaseGameEvent<char> { }
}