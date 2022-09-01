using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The bool Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Boolean, BoolGameEvent}"/>
    [CreateAssetMenu(fileName = "BoolVariable.asset", menuName = Utility.VariableSubmenu + "bool",
        order = Utility.AssetMenuOrderVariables + 2)]
    public sealed class BoolVariable : BaseVariable<bool, BoolGameEvent> { }
}