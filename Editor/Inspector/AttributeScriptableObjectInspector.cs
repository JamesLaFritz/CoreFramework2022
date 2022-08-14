// AttributeScriptableObjectInspector.cs
// 08-13-2022
// James LaFritz

using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Inspector
{
    /// <summary>
    /// Custom editor for all ScriptableObject scripts in order to draw buttons for all button attributes (<see cref="CoreFramework.Attributes.ButtonAttribute"/>).
    /// <a href="https://docs.unity3d.com/ScriptReference/Editor.html">UnityEditor.Editor</a>
    /// </summary>
    [CustomEditor(typeof(ScriptableObject), true, isFallback = true)]
    [CanEditMultipleObjects]
    public class AttributeScriptableObjectInspector : AttributeMonoBehaviourInspector { }
}