// ScriptableObjectButtonsEditor.cs
// 07-19-2022
// James LaFritz

using CoreFramework.Attributes;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Inspector.InspectorButton
{
    /// <summary>
    /// Custom editor for all ScriptableObject scripts in order to draw buttons for all button attributes (<see cref="ButtonAttribute"/>).
    /// </summary>
    [CustomEditor(typeof(ScriptableObject), true, isFallback = true)]
    [CanEditMultipleObjects]
    public sealed class AttributeScriptableObjectInspector : Editor
    {
        /// <summary>
        /// The button attribute helper
        /// </summary>
        private readonly ButtonAttributeHelper m_helper = new ButtonAttributeHelper();

        private void OnEnable()
        {
            m_helper.Init(target);
        }

        #region Overrides of Editor

        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            m_helper.DrawButtons();
        }

        // /// <inheritdoc />
        // public override VisualElement CreateInspectorGUI()
        // {
        //     VisualElement root = base.CreateInspectorGUI();
        //     VisualElement buttonContainer = m_helper.CreateButtons();
        //     if (buttonContainer != null)
        //     {
        //         root.Add(buttonContainer);
        //     }
        //
        //     return root;
        // }

        #endregion
    }
}