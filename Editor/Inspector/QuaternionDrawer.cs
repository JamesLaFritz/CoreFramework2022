// QuaternionDrawer.cs
// 07-19-2022
// James LaFritz

using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor.Inspector
{
    /// <summary>
    /// A property drawer for Quaternion
    /// <seealso href="https://docs.unity3d.com/ScriptReference/PropertyDrawer.html"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(Quaternion))]
    public class QuaternionDrawer : PropertyDrawer
    {
        #region Overrides of PropertyDrawer

        /// <inheritdoc />
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Vector4 vector = property.quaternionValue.ToVector4();

            vector = EditorGUI.Vector4Field(position, label, vector);

            property.quaternionValue = vector.ToQuaternion();
        }

        /// <inheritdoc />
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 1.5f;
        }

        #endregion
    }
}