using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Layer Mask Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{LayerMask, LayerMaskGameEvent}"/>
    [CreateAssetMenu(fileName = "LayerMaskVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "LayerMask",
        order = Utility.AssetMenuOrderVariables + 16)]
    public class LayerMaskVariable : BaseVariable<LayerMask, LayerMaskGameEvent> { }
}