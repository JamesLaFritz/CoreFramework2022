using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Animation Curve Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{AnimationCurve, AnimationCurveGameEvent}"/>
    [CreateAssetMenu(fileName = "AnimationCurveVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "AnimationCurve",
        order = Utility.AssetMenuOrderVariables + 13)]
    public class AnimationCurveVariable : BaseVariable<AnimationCurve, AnimationCurveGameEvent> { }
}