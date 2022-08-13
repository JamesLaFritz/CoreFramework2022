// Vector4Drawer.cs
// 07-19-2022
// James LaFritz

using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Inspector
{
    /// <summary>
    /// The vector drawer class
    /// </summary>
    /// <seealso cref="PropertyDrawer"/>
    [CustomPropertyDrawer(typeof(Vector4), true)]
    public class Vector4Drawer : PropertyDrawer
    {
        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.vector4Value = EditorGUI.Vector4Field(position, label, property.vector4Value);
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 1.5f;
        }

        #endregion
    }
}