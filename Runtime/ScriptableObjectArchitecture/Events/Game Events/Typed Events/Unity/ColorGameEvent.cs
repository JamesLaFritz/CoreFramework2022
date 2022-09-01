using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "ColorGameEvent.asset",
        menuName = Utility.GameEventStructs + "Color",
        order = Utility.AssetMenuOrderEvents + 12)]
    public sealed class ColorGameEvent : BaseGameEvent<Color> { }
}