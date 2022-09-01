using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Vector4 Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Vector4, Vector4GameEvent}"/>
    [CreateAssetMenu(fileName = "Vector4Variable.asset", menuName = Utility.StructsSubmenu + "Vector4",
        order = Utility.AssetMenuOrderVariables + 8)]
    public class Vector4Variable : BaseVariable<Vector4, Vector4GameEvent> { }
}