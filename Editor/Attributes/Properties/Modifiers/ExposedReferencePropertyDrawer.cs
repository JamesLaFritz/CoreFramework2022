#region Header
// ExposedReferencePropertyDrawer.cs
// Author: James LaFritz
// Description: Provides a custom property drawer for properties marked with the ExposedReferenceAttribute. This drawer displays the main property as a field without a label and presents a foldout next to it, which, when expanded, will show the properties of the referenced object.
#endregion

using CoreFramework.Attributes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace CoreFrameworkEditor.Attributes
{
    /// <summary>
    /// Provides a custom property drawer for properties marked with the ExposedReferenceAttribute.
    /// This drawer displays the main property as a field without a label and presents a foldout
    /// next to it, which, when expanded, will show the properties of the referenced object.
    /// </summary>
    /// <remarks>
    /// This property drawer is intended for use with the Unity Editor and requires the UI Toolkit package.
    /// It assumes that ExposedReferenceAttribute is defined in the CoreFramework.Attributes namespace.
    /// </remarks>
    [CustomPropertyDrawer(typeof(ExposedReferenceAttribute))]
    public class ExposedReferencePropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// A private Editor field, potentially for added Editor functionalities.
        /// </summary>
        /// <remarks>
        /// Currently unused in the provided code.
        /// </remarks>
        private Editor _editor;
        
        #region Overrides of PropertyDrawer
        
        /// <inheritdoc />
        /// <summary>
        /// Creates a custom GUI for the property in the Unity Inspector.
        /// </summary>
        /// <param name="property">The SerializedProperty to make a custom GUI for.</param>
        /// <returns>The VisualElement representing the custom GUI.</returns>
        /// <remarks>
        /// This method organizes the GUI elements in a specific layout with a main property field and a foldout.
        /// When the property references an object, the foldout will display the properties of that object.
        /// </remarks>
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Root container for everything
            var rootContainer = new VisualElement();

            // Create horizontal container with row flex direction
            var horizontalContainer = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row
                }
            };
            rootContainer.Add(horizontalContainer);

            // Create the property field for the object reference itself
            var propertyField = new PropertyField(property, "")
            {
                name = "propertyField", // Assign a name for styling or future reference
                style = { flexGrow = 1 } // Allow it to grow and fill available space
            };

            // Create the foldout for the nested properties (no text for this foldout)
            var foldout = new Foldout
            {
                text = property.displayName
            };
            horizontalContainer.Add(foldout);
            horizontalContainer.Add(propertyField);
            
            // If the property is a reference to an object, we create property fields for its properties
            if (property.objectReferenceValue != null)
            {
                // Create a SerializedObject from the ScriptableObject to access its properties
                var serializedObject = new SerializedObject(property.objectReferenceValue);
                serializedObject.Update();

                var prop = serializedObject.GetIterator();
                if (prop.NextVisible(true)) // Start with the first visible property
                {
                    do
                    {
                        // Skip drawing the script reference
                        if (prop.name == "m_Script") continue;

                        var childField = new PropertyField(prop.Copy());
                        childField.Bind(serializedObject);
                        foldout.Add(childField);
                    }
                    while (prop.NextVisible(false)); // Iterate over all the visible properties
                }
            }

            // Listen for changes and apply them to the serialized object of the reference
            foldout.RegisterValueChangedCallback(_ =>
            {
                if (property.objectReferenceValue != null)
                {
                    SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
                    serializedObject.Update();
                    serializedObject.ApplyModifiedProperties();
                    property.serializedObject.ApplyModifiedProperties();
                }
            });

            return rootContainer;
        }

        #endregion
    }
}
