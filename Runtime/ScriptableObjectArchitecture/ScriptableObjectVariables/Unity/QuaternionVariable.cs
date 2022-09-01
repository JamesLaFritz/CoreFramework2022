using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Quaternion Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Quaternion, QuaternionGameEvent}"/>
    [CreateAssetMenu(fileName = "QuaternionVariable.asset", menuName = Utility.StructsSubmenu + "Quaternion",
        order = Utility.AssetMenuOrderVariables + 9)]
    public sealed class QuaternionVariable : BaseVariable<Quaternion, QuaternionGameEvent> { }
}