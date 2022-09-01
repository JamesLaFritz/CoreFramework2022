using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Vector3 Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Vector3, Vector3GameEvent}"/>
    [CreateAssetMenu(fileName = "Vector3Variable.asset", menuName = Utility.StructsSubmenu + "Vector3",
        order = Utility.AssetMenuOrderVariables + 7)]
    public sealed class Vector3Variable : BaseVariable<Vector3, Vector3GameEvent> { }
}