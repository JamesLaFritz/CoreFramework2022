using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// The Object Scriptable Object Variable.
    /// </summary>
    /// <seealso cref="BaseVariable{Object, ObjectGameEvent}"/>
    [CreateAssetMenu(fileName = "ObjectVariable.asset", menuName = Utility.VariableSubmenu + "Object",
        order = Utility.AssetMenuOrderVariables + 5)]
    public class ObjectVariable : BaseVariable<Object, ObjectGameEvent>
    {
        #region Overrides of BaseVariable<Object,ObjectGameEvent>

        /// <inheritdoc />
        public override string ToString()
        {
            if (Value == null || string.IsNullOrEmpty(Value.name)) return "object is null";
            return Value.name;
        }

        #endregion
    }
}