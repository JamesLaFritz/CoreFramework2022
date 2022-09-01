using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Char Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Char, CharGameEvent}"/>
    [CreateAssetMenu(fileName = "CharVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "Char",
        order = Utility.AssetMenuOrderVariables + 19)]
    public sealed class CharVariable : BaseVariable<char, CharGameEvent> { }
}