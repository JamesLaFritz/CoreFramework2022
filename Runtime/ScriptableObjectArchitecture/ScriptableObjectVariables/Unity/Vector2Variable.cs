using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Vector2 Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Vector2, Vector2GameEvent}"/>
    [CreateAssetMenu(fileName = "Vector2Variable.asset", menuName = Utility.StructsSubmenu + "Vector2",
        order = Utility.AssetMenuOrderVariables + 6)]
    public sealed class Vector2Variable : BaseVariable<Vector2, Vector2GameEvent> { }
}