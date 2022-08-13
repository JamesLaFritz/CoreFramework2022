// BehaviourButtonsEditor.cs
// 07-19-2022
// James LaFritz

using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Inspector.InspectorButton
{
    /// <summary>
    /// Custom editor for all MonoBehaviour scripts in order to draw buttons for all button attributes (<see cref="CoreFramework.Attributes.ButtonAttribute"/>).
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
    [CanEditMultipleObjects]
    public sealed class BehaviourButtonsEditor : Editor
    {
        /// <summary>
        /// The button attribute helper
        /// </summary>
        private readonly ButtonAttributeHelper _helper = new ButtonAttributeHelper();

        private void OnEnable()
        {
            _helper.Init(target);
        }

        #region Overrides of Editor

        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            _helper.DrawButtons();
        }

        // /// <inheritdoc />
        // public override VisualElement CreateInspectorGUI()
        // {
        //     VisualElement root = base.CreateInspectorGUI() ?? new VisualElement();
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