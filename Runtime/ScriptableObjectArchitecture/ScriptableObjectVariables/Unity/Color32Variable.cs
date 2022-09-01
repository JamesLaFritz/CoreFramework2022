using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Color32 Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Color32, Color32GameEvent}"/>
    [CreateAssetMenu(fileName = "Color32Variable.asset", menuName = Utility.StructsSubmenu + "Color32",
        order = Utility.AssetMenuOrderVariables + 11)]
    public class Color32Variable : BaseVariable<Color32, Color32GameEvent> { }
}