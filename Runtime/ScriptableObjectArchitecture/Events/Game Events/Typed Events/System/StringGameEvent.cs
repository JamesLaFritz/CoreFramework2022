using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "StringGameEvent.asset",
        menuName = Utility.GameEvent + "String",
        order = Utility.AssetMenuOrderEvents + 3)]
    public sealed class StringGameEvent : BaseGameEvent<string> { }
}