using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "IntGameEvent.asset",
        menuName = Utility.GameEvent + "Int",
        order = Utility.AssetMenuOrderEvents + 1)]
    public sealed class IntGameEvent : BaseGameEvent<int> { }
}