using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework.ScriptableObjectArchitecture.ScriptableObjectVariables
{
    /// <summary>
    /// Scriptable constant variable whose scene values are assigned at
    /// edit-time by assigning a <see cref="UnityEditor.SceneAsset"/> instance to it.
    /// </summary>
    [CreateAssetMenu(fileName = "SceneVariable.asset", menuName = Utility.AdvancedVariableSubmenu + "Scene",
        order = Utility.AssetMenuOrderVariables + 15)]
    public sealed class SceneVariable : BaseVariable<SceneInfo, SceneGameEvent>
    {
        #region Unity Methods

        /// <summary>
        /// Reset to default values.
        /// </summary>
        private void Reset()
        {
            readOnly = true;
        }

        #endregion
    }
}