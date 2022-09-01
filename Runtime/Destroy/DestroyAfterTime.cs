// DestroyAfterTime.cs
// 07-21-2022
// James LaFritz

using UnityEngine;

namespace CoreFramework.Destroy
{
    /// <summary>
    /// A <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a> that
    /// destroys the game object after a specified amount of time.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    public class DestroyAfterTime : MonoBehaviour
    {
        /// <summary>
        /// The time to live
        /// </summary>
        [SerializeField] private float timeToLive = 6;

        /// <summary>
        /// Starts this instance
        /// </summary>
        private void Start() => Destroy(gameObject, timeToLive);
    }
}