using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Bounds Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Bounds, BoundsGameEvent}"/>
    [CreateAssetMenu(fileName = "BoundsVariable.asset", menuName = Utility.StructsSubmenu + "Bounds",
        order = Utility.AssetMenuOrderVariables + 10)]
    public class BoundsVariable : BaseVariable<Bounds, BoundsGameEvent> { }
}