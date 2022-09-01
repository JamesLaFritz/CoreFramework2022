using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "QuaternionGameEvent.asset",
        menuName = Utility.GameEventStructs + "Quaternion",
        order = Utility.AssetMenuOrderEvents + 9)]
    public sealed class QuaternionGameEvent : BaseGameEvent<Quaternion> { }
}