using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Audio Clip Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{AudioClip, AudioClipGameEvent}"/>
    [CreateAssetMenu(fileName = "AudioClipVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "AudioClip",
        order = Utility.AssetMenuOrderVariables + 14)]
    public class AudioClipVariable : BaseVariable<AudioClip, AudioClipGameEvent> { }
}