// CreateGameObjectFromUnityScript.cs
// 07-21-2022
// James LaFritz

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CoreFrameworkEditor
{
    /// <summary>
    /// This editor script reacts too dragging and dropping in the editor
    /// and creates a new <see cref="GameObject"/> with the name of a <see cref="MonoBehaviour"/> script that is being dropped.
    /// </summary>
    [InitializeOnLoad]
    public class CreateGameObjectFromUnityScript
    {
        /// <summary>
        /// The current objects in the hierarchy. Used for calculating the area where items can be dropped.
        /// </summary>
        private static readonly Dictionary<int, Rect> HierarchyObjects = new Dictionary<int, Rect>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGameObjectFromUnityScript"/> class
        /// </summary>
        static CreateGameObjectFromUnityScript()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyItemGUI;
        }

        /// <summary>
        /// This function gets called by the Unity Editor and is used to intercept Editor actions.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rect"></param>
        private static void OnHierarchyItemGUI(int id, Rect rect)
        {
            Event evt = Event.current;

            // Get the current hierarchy objects and add them to the dictionary if they are not already in it.
            GameObject go = (GameObject)EditorUtility.InstanceIDToObject(id);
            if (go != null && !HierarchyObjects.ContainsKey(id))
            {
                HierarchyObjects.Add(id, rect);
            }

            // Checks if a drag event is occuring if so check if the cursor is over any hierarchy object
            // and if not so and it is a MonoBehaviour script that is being dragged create a new GameObject
            // with the name of the script that is being dragged.
            if (evt.type == EventType.DragUpdated || evt.type == EventType.DragPerform)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                bool overObject = false;

                // Use the filled dictionary to check if the cursor is being dragged over an object in the hierarchy.
                foreach (KeyValuePair<int, Rect> pair in HierarchyObjects)
                {
                    overObject = pair.Value.Contains(Event.current.mousePosition);
                    if (overObject) break;
                }

                if (!overObject)
                {
                    if (evt.type == EventType.DragPerform)
                    {
                        if (DragAndDrop.objectReferences.Length == 1 &&
                            DragAndDrop.objectReferences[0] is MonoScript)
                        {
                            var monoScript = DragAndDrop.objectReferences[0] as MonoScript;
                            Debug.Assert(monoScript != null, nameof(monoScript) + " != null");
                            // Check if the dragged object is a script
                            var type = monoScript.GetClass();
                            if (type == null || !type.IsSubclassOf(typeof(MonoBehaviour)))
                            {
                                Debug.LogWarning($"Can not add {monoScript.name} to Scene as {monoScript.GetType()} is not a MonoBehaviour");
                            }
                            else
                            {
                                // Create a new GameObject and add the script as a component.
                                var newGo = new GameObject(DragAndDrop.objectReferences[0].name);
                                Selection.activeGameObject = newGo;
                                var component = newGo.AddComponent(type);
                                Undo.RegisterCreatedObjectUndo(newGo, $"Created {newGo.name}");
                                if (component != null)
                                {
                                    while (UnityEditorInternal.ComponentUtility.MoveComponentUp(component)) ;

                                    EditorApplication.delayCall += () =>
                                    {
                                        var sceneHierarchyType =
                                            System.Type.GetType("UnityEditor.SceneHierarchyWindow,UnityEditor");
                                        var hierarchyWindow = EditorWindow.GetWindow(sceneHierarchyType);
                                        hierarchyWindow.SendEvent(EditorGUIUtility.CommandEvent("Rename"));
                                    };
                                }
                                else Undo.PerformUndo();
                            }
                        }
                    }

                    Event.current.Use();
                }
            }

            // Detect if a hierarchy item is being deleted so that we can update the hierarchy objects dictionary.
            if (Event.current.commandName == "Delete" || Event.current.commandName == "SoftDelete")
            {
                HierarchyObjects.Clear();
            }
        }
    }
}