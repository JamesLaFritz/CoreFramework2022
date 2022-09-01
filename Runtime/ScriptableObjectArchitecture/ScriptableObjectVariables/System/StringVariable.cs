using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The String Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{String, StringGameEvent}"/>
    [CreateAssetMenu(fileName = "StringVariable.asset", menuName = Utility.VariableSubmenu + "String",
        order = Utility.AssetMenuOrderVariables + 3)]
    public sealed class StringVariable : BaseVariable<string, StringGameEvent> { }
}