using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Color Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Color, ColorGameEvent}"/>
    [CreateAssetMenu(fileName = "ColorVariable.asset", menuName = Utility.StructsSubmenu + "Color",
        order = Utility.AssetMenuOrderVariables + 12)]
    public class ColorVariable : BaseVariable<Color, ColorGameEvent> { }
}