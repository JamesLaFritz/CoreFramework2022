using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.Events
{
    [CreateAssetMenu(
        fileName = "AudioClipGameEvent.asset",
        menuName = Utility.AdvancedGameEvent + "AudioClip",
        order = Utility.AssetMenuOrderEvents + 14)]
    public sealed class AudioClipGameEvent : BaseGameEvent<AudioClip> { }
}