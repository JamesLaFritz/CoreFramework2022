#region Description

// PropertyDrawerHelper.cs
// 09-07-2021
// James LaFritz
//
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147

#endregion

using System;
using System.Reflection;
using CoreFramework;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor
{
    /// <summary>
    /// Collection of helper methods when coding a PropertyDrawer editor.
    /// Bit Cake Studio's BitStrap
    /// https://assetstore.unity.com/publishers/4147
    /// </summary>
    public static class PropertyDrawerHelper
    {
        public static T GetAttribute<T>(this SerializedProperty self) where T : Attribute
        {
            FieldInfo fieldInfo = self.serializedObject.targetObject.GetType().GetField(self.name);
            if (fieldInfo == null) return null;

            Option<T> attribute = fieldInfo.GetCustomAttributes(typeof(T), true)
                .First()
                .Select(a => a as T);
            return attribute.Match(
                some: a => a,
                none: () => null);
        }

        /// <summary>
        /// Finds the specified property by it's name.
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="propertyName">The property name</param>
        /// <param name="errorMessage">The error message</param>
        /// <returns>The serialized property</returns>
        public static SerializedProperty FindProperty(SerializedProperty property, string propertyName,
                                                      out string errorMessage)
        {
            SerializedProperty prop = property.serializedObject.FindProperty(propertyName);
            errorMessage = string.Empty;
            if (prop != null) return prop;
            string propPath =
                property.propertyPath.Substring(
                    0, property.propertyPath.IndexOf($".{property.name}", StringComparison.Ordinal));
            prop = property.serializedObject.FindProperty($"{propPath}.{propertyName}");
            if (prop != null) return prop;
            errorMessage = $"The Field name {propertyName} cannot be found in {propPath}";
            return null;
        }

        public static bool ShouldShow(bool showIfProp, bool show)
        {
            if ((showIfProp && show) || (!showIfProp && !show))
                return true;
            return false;
        }
    }
}
