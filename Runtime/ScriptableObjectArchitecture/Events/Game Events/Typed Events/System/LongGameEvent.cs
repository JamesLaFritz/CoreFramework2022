using System;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [Serializable]
    [CreateAssetMenu(
        fileName = "LongGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "Long",
        order = Utility.AssetMenuOrderEvents + 18)]
    public sealed class LongGameEvent : BaseGameEvent<long> { }
}