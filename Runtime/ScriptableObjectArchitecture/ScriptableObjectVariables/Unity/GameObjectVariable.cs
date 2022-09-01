using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Game Object Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{GameObject, GameObjectGameEvent}"/>
    [CreateAssetMenu(fileName = "GameObjectVariable.asset", menuName = Utility.VariableSubmenu + "GameObject",
        order = Utility.AssetMenuOrderVariables + 4)]
    public sealed class GameObjectVariable : BaseVariable<GameObject, GameObjectGameEvent> { }
}