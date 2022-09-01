using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "SByteGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "SByte",
        order = Utility.AssetMenuOrderEvents + 22)]
    public sealed class SByteGameEvent : BaseGameEvent<sbyte> { }
}