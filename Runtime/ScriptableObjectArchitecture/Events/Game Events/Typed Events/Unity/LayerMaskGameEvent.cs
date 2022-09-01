using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "LayerMaskGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "LayerMask",
        order = Utility.AssetMenuOrderEvents + 16)]
    public sealed class LayerMaskGameEvent : BaseGameEvent<LayerMask> { }
}