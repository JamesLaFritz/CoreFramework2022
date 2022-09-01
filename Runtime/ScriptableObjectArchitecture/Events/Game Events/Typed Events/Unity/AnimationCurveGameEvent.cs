using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "AnimationCurveGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "AnimationCurve",
        order = Utility.AssetMenuOrderEvents + 13)]
    public sealed class AnimationCurveGameEvent : BaseGameEvent<AnimationCurve> { }
}