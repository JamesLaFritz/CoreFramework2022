using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "ByteGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "Byte",
        order = Utility.AssetMenuOrderEvents + 21)]
    public sealed class ByteGameEvent : BaseGameEvent<byte> { }
}