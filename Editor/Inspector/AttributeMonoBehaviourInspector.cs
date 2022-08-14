// AttributeMonoBehaviourInspector.cs
// 08-13-2022
// James LaFritz

using UnityEditor;
using UnityEngine;
using IconAttribute = CoreFramework.Attributes.Properties.Modifiers.IconAttribute;

namespace CoreFrameworkEditor.Inspector
{
    /// <summary>
    /// Custom editor for all MonoBehaviour scripts in order to draw buttons for all button attributes (<see cref="CoreFramework.Attributes.ButtonAttribute"/>).
    /// <a href="https://docs.unity3d.com/ScriptReference/Editor.html">UnityEditor.Editor</a>
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
    [CanEditMultipleObjects]
    public class AttributeMonoBehaviourInspector : Editor
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
            DoDrawDefaultInspector(serializedObject);
            _helper.DrawButtons();
        }

        #endregion

        protected static bool DoDrawDefaultInspector(SerializedObject obj)
        {
            if (obj == null) return false;
            using (EditorGUI.ChangeCheckScope changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                obj.UpdateIfRequiredOrScript();
                SerializedProperty iterator = obj.GetIterator();
                for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
                {
                    try
                    {
                        GUIContent label = new GUIContent(iterator.displayName);

                        IconAttribute iconAttribute = iterator.GetAttribute<IconAttribute>();
                        if (iconAttribute != null)
                            label.image = EditorGUIUtility.FindTexture(iconAttribute.Path);
                        TooltipAttribute tooltipAttribute = iterator.GetAttribute<TooltipAttribute>();
                        if (tooltipAttribute != null)
                            label.tooltip = tooltipAttribute.tooltip;

                        using (new EditorGUI.DisabledScope("m_Script" == iterator.propertyPath))
                            EditorGUILayout.PropertyField(iterator, label, true);
                    }
                    catch (System.Exception e)
                    {
                        switch (e)
                        {
                            case System.InvalidOperationException:
                            case ExitGUIException:
                                continue;
                            default:
                                Debug.LogWarning(e);
                                break;
                        }
                    }
                }

                obj.ApplyModifiedProperties();
                return changeCheckScope.changed;
            }
        }
    }
}