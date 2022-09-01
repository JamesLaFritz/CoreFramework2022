using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "FloatGameEvent.asset",
        menuName = Utility.GameEvent + "Float",
        order = Utility.AssetMenuOrderEvents)]
    public sealed class FloatGameEvent : BaseGameEvent<float> { }
}