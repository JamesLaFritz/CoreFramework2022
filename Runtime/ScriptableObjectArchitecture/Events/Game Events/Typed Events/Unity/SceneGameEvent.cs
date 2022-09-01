using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "SceneGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "Scene",
        order = Utility.AssetMenuOrderEvents + 15)]
    public sealed class SceneGameEvent : BaseGameEvent<SceneInfo> { }
}