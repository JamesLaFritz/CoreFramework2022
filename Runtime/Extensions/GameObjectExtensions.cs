#region Header
// GameObjectExtensions.cs
// Author: James LaFritz
// Description: Provides extension methods for the UnityEngine.GameObject class.
#endregion

using UnityEngine;

namespace CoreFramework.Extensions
{
    /// <summary>
    /// Provides extension methods for the <a href="https://docs.unity3d.com/ScriptReference/GameObject.html">UnityEngine.GameObject</a> class.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Retrieves a component of the specified type if it exists on the game object.
        /// If it doesn't exist, a new component of the specified type is added and returned.
        /// </summary>
        /// <typeparam name="T">The type of component to retrieve or add.</typeparam>
        /// <param name="gameObject">The game object this method extends.</param>
        /// <returns>The existing component of type T if found; otherwise, a new component of type T.</returns>
        public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            return component != null ? component : gameObject.AddComponent<T>();
        }
        
        /// <summary>
        /// Returns the object itself if it exists, null otherwise.
        /// </summary>
        /// <remarks>
        /// This method helps differentiate between a null reference and a destroyed Unity object. Unity's "== null" check
        /// can incorrectly return true for destroyed objects, leading to misleading behaviour. The OrNull method use
        /// Unity's "null check", and if the object has been marked for destruction, it ensures an actual null reference is returned,
        /// aiding in correctly chaining operations and preventing NullReferenceExceptions.
        /// </remarks>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object being checked.</param>
        /// <returns>The object itself if it exists and not destroyed, null otherwise.</returns>
        public static T OrNull<T> (this T obj) where T : Object => obj ? obj : null;
    
        /// <summary>
        /// Destroys all children of the game object
        /// </summary>
        /// <param name="gameObject">GameObject whose children are to be destroyed.</param>
        public static void DestroyChildren(this GameObject gameObject)
        {
            gameObject.transform.DestroyChildren();
        }
    
        /// <summary>
        /// Immediately destroys all children of the given GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject whose children are to be destroyed.</param>
        public static void DestroyChildrenImmediate(this GameObject gameObject)
        {
            gameObject.transform.DestroyChildrenImmediate();
        }
    
        /// <summary>
        /// Enables all child GameObjects associated with the given GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject whose child GameObjects are to be enabled.</param>
        public static void EnableChildren(this GameObject gameObject)
        {
            gameObject.transform.EnableChildren();
        }
        
        /// <summary>
        /// Disables all child GameObjects associated with the given GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject whose child GameObjects are to be disabled.</param>
        public static void DisableChildren(this GameObject gameObject)
        {
            gameObject.transform.DisableChildren();
        }        

        /// <summary>
        /// Resets the GameObject's transform's position, rotation, and scale to their default values.
        /// </summary>
        /// <param name="gameObject">GameObject whose transformation is to be reset.</param>
        public static void ResetTransformation(this GameObject gameObject)
        {
            gameObject.transform.Reset();
        }
    }
}
