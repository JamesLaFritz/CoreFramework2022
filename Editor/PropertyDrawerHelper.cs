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
using CoreFramework.Functional;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using IconAttribute = CoreFramework.Attributes.Properties.Modifiers.IconAttribute;

namespace CoreFrameworkEditor
{
    /// <summary>
    /// Collection of helper methods when coding a PropertyDrawer editor.
    /// Bit Cake Studio's BitStrap
    /// https://assetstore.unity.com/publishers/4147
    /// </summary>
    public static class PropertyDrawerHelper
    {
        /// <summary>
        /// If the target property has a [Tooltip] attribute, load it into its label.
        /// </summary>
        private static void LoadAttributeTooltip(PropertyDrawer self, GUIContent label)
        {
            Option<TooltipAttribute> attribute = self.fieldInfo
                .GetCustomAttributes(typeof(TooltipAttribute), true)
                .First()
                .Select(a => a as TooltipAttribute);

            label.tooltip = attribute.Match(
                some: a => a.tooltip,
                none: () => "");
        }

        /// <summary>
        /// If the target property has a [Icon] attribute, load it into its label.
        /// </summary>
        private static void LoadAttributeIcon(PropertyDrawer self, GUIContent label)
        {
            Option<IconAttribute> attribute = self.fieldInfo
                .GetCustomAttributes(typeof(IconAttribute), true)
                .First()
                .Select(a => a as IconAttribute);

            label.image = attribute.Match(
                some: a => EditorGUIUtility.FindTexture(a.Path),
                none: () => null);
        }

        /// <summary>
        /// Loads all of the attributes that are needed to modify the label.
        /// </summary>
        public static void LoadAttributes(PropertyDrawer self, GUIContent label)
        {
            LoadAttributeTooltip(self, label);
            LoadAttributeIcon(self, label);
        }

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

        public static VisualElement CreateIconGUI(string iconPath)
        {
            Texture texture = EditorGUIUtility.FindTexture(iconPath);
            Image icon = new Image
            {
                image = texture,
                scaleMode = ScaleMode.ScaleToFit,
                style =
                {
                    width = 16,
                    height = 16
                }
            };
            return icon;
        }

        public static bool ShouldShow(bool showIfProp, bool show)
        {
            if ((showIfProp && show) || (!showIfProp && !show))
                return true;
            return false;
        }
    }
}
