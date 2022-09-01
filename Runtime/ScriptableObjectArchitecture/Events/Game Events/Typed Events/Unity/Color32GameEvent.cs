using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "Color32GameEvent.asset",
        menuName = Utility.GameEventStructs + "Color32",
        order = Utility.AssetMenuOrderEvents + 11)]
    public sealed class Color32GameEvent : BaseGameEvent<Color32> { }
}