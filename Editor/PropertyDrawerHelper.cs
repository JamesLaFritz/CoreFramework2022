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
using CoreFramework.Extensions;
using CoreFramework.Functional;
using UnityEditor;

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
        /// <param name="self">The reference property from which to search.</param>
        /// <param name="propertyName">The name of the property to find.</param>
        /// <param name="errorMessage">Output parameter that will contain an error message if the property isn't found.</param>
        /// <returns>The found SerializedProperty, or null if it couldn't be found.</returns>
        public static SerializedProperty FindProperty(this SerializedProperty self, string propertyName,
                                                      out string errorMessage)
        {
            var prop = self.serializedObject.FindProperty(propertyName);
            errorMessage = string.Empty;
            if (prop != null) return prop;
            if (!self.propertyPath.Contains($".{self.name}")) return null;
            var propPath =
                self.propertyPath.Substring(
                    0, self.propertyPath.IndexOf($".{self.name}", StringComparison.Ordinal));
            prop = self.serializedObject.FindProperty($"{propPath}.{propertyName}");
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
