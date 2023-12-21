#region Description

// PropertyDrawerHelper.cs
// 09-07-2021
// James LaFritz
//
// From Bit Cake Studio's BitStrap
// https://assetstore.unity.com/publishers/4147

#endregion

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    public static class SerializedPropertyExtensions
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
        public static SerializedProperty FindSerializedProperty(this SerializedProperty self, string propertyName,
                                                      out string errorMessage)
        {
            var prop = self.serializedObject.FindProperty(propertyName);
            errorMessage = string.Empty;
            if (prop != null) return prop;
            var propPath = "";

            if (self.propertyPath.Contains($".{self.name}"))
                propPath =
                    self.propertyPath.Substring(
                        0, self.propertyPath.IndexOf($".{self.name}", StringComparison.Ordinal)) +
                    ".";
            prop = self.serializedObject.FindProperty($"{propPath}{propertyName}");
            if (prop != null) return prop;
            errorMessage = $"The Field name {propertyName} cannot be found in {propPath}";
            return null;
        }
        
        public static Object GetTargetedObject(this SerializedProperty self) => self.serializedObject.targetObject;

        public static Type GetTargetedObjectType(this SerializedProperty self) => self.GetTargetedObject().GetType();

        public static FieldInfo[] GetFieldInfoArray(this SerializedProperty self) =>
            self.GetTargetedObjectType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() == null)
                .ToArray();

        /// <summary>
        /// Returns the FieldInfo object that represents the field with the specified name in the target object of the serialized property.
        /// </summary>
        /// <param name="self">The serialized property.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The FieldInfo object that represents the field with the specified name in the target object of the serialized property.</returns>
        public static FieldInfo FindField(this SerializedProperty self, string fieldName) =>
            self.GetTargetedObjectType().GetField(fieldName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        public static object GetValueOfField(this SerializedProperty self, string fieldName)
        {
            var obj = self.GetTargetedObject();
            var field = self.FindField(fieldName);
            if (field != null) return field.GetValue(obj);
            return null;
        }

        /// <summary>
        /// Determines whether a property should be shown based on two boolean conditions.
        /// </summary>
        /// <param name="self">The SerializedProperty to show</param>
        /// <param name="showIfProp">The first boolean condition.</param>
        /// <param name="show">The second boolean condition.</param>
        /// <returns>True if the conditions match, otherwise false.</returns>
        public static bool ShouldShow(this SerializedProperty self, bool showIfProp, bool show)
        {
            return (showIfProp && show) || (!showIfProp && !show);
        }
    }
}
