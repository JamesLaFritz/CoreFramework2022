using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "DoubleGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "Double",
        order = Utility.AssetMenuOrderEvents + 17)]
    public sealed class DoubleGameEvent : BaseGameEvent<double> { }
}