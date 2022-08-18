// DestroyNoChildren.cs
// 07-21-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework
{
    /// <summary>
    /// A <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a> that
    /// destroys the GameObject it is attached to if it has no children.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    public class DestroyNoChildren : MonoBehaviour
    {
        /// <summary>
        /// Updates this instance
        /// </summary>
        private void Update()
        {
            if (transform.childCount < 1)
                Destroy(gameObject);
        }
    }
}