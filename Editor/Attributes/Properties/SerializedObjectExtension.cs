#region Header
// SerializedObjectExtensions.cs
// Author: James LaFritz
// Description: This class contains extension methods for SerializedObject.
#endregion

using System;
using UnityEditor;

namespace CoreFrameworkEditor.Attributes
{
    public static class SerializedObjectExtensions
    {
        /// <summary>
        /// Registers a callback to be invoked when a specific property of a serialized object changes.
        /// Returns an Action that should be called to unsubscribe from the event when monitoring is no longer needed.
        /// </summary>
        /// <param name="serializedObject">The serialized object containing the property to watch.</param>
        /// <param name="property">The serialized property to watch for changes.</param>
        /// <param name="callback">The action to invoke when a change is detected on the property.</param>
        /// <returns>An Action that unsubscribes the change monitoring when invoked.</returns>
        /// <example>
        /// Here is an example of how to use OnPropertyChanged:
        /// <code>
        /// SerializedProperty myProperty = serializedObject.FindProperty("myPropertyName");
        /// Action unsubscribe = serializedObject.OnPropertyChanged(myProperty, () =>
        /// {
        ///     Debug.Log("Property value changed!");
        /// });
        /// // When you want to stop monitoring changes
        /// unsubscribe();
        /// </code>
        /// </example>
        public static Action OnPropertyChanged(this SerializedObject serializedObject, SerializedProperty property,
            Action callback)
        {
            // Store the initial value to compare against for changes
            var initialValue = GetPropertyValue(property);

            // Subscribe to the EditorApplication.update event
            EditorApplication.update += CheckForChange;

            // Return a delegate to unsubscribe
            Action unsubscribe = () =>
            {
                EditorApplication.update -= CheckForChange;
                unsubscribe = null; // Prevent multiple unsubscription
            };

            return unsubscribe;

            void CheckForChange()
            {
                if (serializedObject == null)
                {
                    // Clean up to avoid memory leaks
                    EditorApplication.update -= CheckForChange;
                    return;
                }

                // Update the serialized object to ensure we have the latest data
                serializedObject.Update();
                
                // Now use a switch or if/else if chain to compare based on property type
                var currentValue = GetPropertyValue(property);

                if (property.hasMultipleDifferentValues || currentValue != initialValue)
                {
                    // Update the initial value to the new value
                    initialValue = GetPropertyValue(property);

                    // The property has changed, invoke the callback
                    callback?.Invoke();
                }

                // Apply the changes to the serialized object
                serializedObject.ApplyModifiedProperties();
            }
        }

        /// <summary>
        /// Gets the value of a serialized property.
        /// </summary>
        /// <param name="property">The serialized property.</param>
        /// <returns>The value of the property.</returns>
        private static object GetPropertyValue(SerializedProperty property)
        {
            return property.propertyType switch
            {
                SerializedPropertyType.Boolean => property.boolValue,
                SerializedPropertyType.Enum => property.enumValueIndex,
                SerializedPropertyType.Generic => property,
                SerializedPropertyType.Integer => property.intValue,
                SerializedPropertyType.Float => property.floatValue,
                SerializedPropertyType.String => property.stringValue,
                SerializedPropertyType.Color => property.colorValue,
                SerializedPropertyType.ObjectReference => property.objectReferenceValue,
                SerializedPropertyType.LayerMask => property,
                SerializedPropertyType.Vector2 => property.vector2Value,
                SerializedPropertyType.Vector3 => property.vector3Value,
                SerializedPropertyType.Vector4 => property.vector4Value,
                SerializedPropertyType.Rect => property.rectValue,
                SerializedPropertyType.ArraySize => property.arraySize,
                SerializedPropertyType.Character => property,
                SerializedPropertyType.AnimationCurve => property.animationCurveValue,
                SerializedPropertyType.Bounds => property.boundsValue,
                SerializedPropertyType.Gradient => property.gradientValue,
                SerializedPropertyType.Quaternion => property.quaternionValue,
                SerializedPropertyType.ExposedReference => property.exposedReferenceValue,
                SerializedPropertyType.FixedBufferSize => property.fixedBufferSize,
                SerializedPropertyType.Vector2Int => property.vector2IntValue,
                SerializedPropertyType.Vector3Int => property.vector3IntValue,
                SerializedPropertyType.RectInt => property.rectIntValue,
                SerializedPropertyType.BoundsInt => property.boundsIntValue,
                SerializedPropertyType.ManagedReference => property.managedReferenceValue,
                SerializedPropertyType.Hash128 => property.hash128Value,
                _ => throw new NotImplementedException(
                    $"Monitoring changes for property type {property.propertyType} is not implemented.")
            };
        }
    }
}
