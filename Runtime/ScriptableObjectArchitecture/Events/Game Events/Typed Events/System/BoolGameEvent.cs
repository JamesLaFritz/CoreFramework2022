using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    /// <summary>
    /// A Game Event that has a bool as an argument.
    /// </summary>
    [CreateAssetMenu(
        fileName = "BoolGameEvent.asset",
        menuName = Utility.GameEvent + "Bool",
        order = Utility.AssetMenuOrderEvents + 2)]
    public sealed class BoolGameEvent : BaseGameEvent<bool> { }
}