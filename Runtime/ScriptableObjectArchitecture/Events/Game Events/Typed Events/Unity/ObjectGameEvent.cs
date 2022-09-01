using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "ObjectGameEvent.asset",
        menuName = Utility.GameEvent + "Object",
        order = Utility.AssetMenuOrderEvents + 5)]
    public sealed class ObjectGameEvent : BaseGameEvent<Object> { }
}