// Interactable.cs
// 07-20-2022
// James LaFritz

using CoreFramework.Attributes;
using UnityEngine;

namespace CoreFramework
{
    /// <summary>
    /// A <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a> that
    /// can be interacted with.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        /// <summary>
        /// Is this a one time use interactable?
        /// </summary>
        [SerializeField] protected bool isOneShot;

        /// <summary>
        /// The amount of time it takes for this interactable to cool down before it can be used again.
        /// </summary>
        [SerializeField, InfoBox("The amount of time it takes for this timer to cool down.", InfoBoxType.None)]
        [ShowIfBool("m_isOneShot")]
        protected float coolDown;

        /// <summary>
        /// The tag of the GameObject that can interact with this item.
        /// </summary>
        [SerializeField, Tag, InfoBox("The tag of the Object that can interact with this")]
        private string interactTag = "Player";

        /// <summary>
        /// Has this interactable been interacted with.
        /// </summary>
        [SerializeField, ReadOnly] protected bool isActivated;

        /// <summary>
        /// can this interactable be used.
        /// </summary>
        [SerializeField, ReadOnly] protected bool canUse = true;

        /// <summary>
        /// The time that this interactable was last used.
        /// </summary>
        private float _mLastUse;

        #region Unity Methods

        /// <summary>
        /// Sent when another object enters a trigger collider attached to this object (2D physics only).
        /// If the other tag is the interact tag will call Interact.
        /// </summary>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(interactTag)) return;

            Interact();
        }

        /// <summary>
        /// When a GameObject collides with another GameObject, Unity calls OnTriggerEnter.
        /// If the other tag is the interact tag will call Interact.
        /// </summary>
        /// <param name="other">The other</param>
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(interactTag)) return;

            Interact();
        }

        #endregion

        /// <summary>
        /// Interact with this interactable.
        /// </summary>
        public void Interact()
        {
            if (!CanInteract())
                return;

            _mLastUse = Time.time;
            isActivated = true;

            OnInteract();
        }

        /// <summary>
        /// On Interact is called when this Interactable is being interacted with.
        /// Must be implemented in child classes. This is what the interactable does.
        /// </summary>
        protected abstract void OnInteract();

        /// <summary>
        /// Describes whether this interactable can be interacted with.
        /// </summary>
        /// <returns>True if the Interactable can be interacted with.</returns>
        public bool CanInteract()
        {
            if (!canUse) return false;
            if (isOneShot && isActivated) return false;
            return IsCoolDownEnded();
        }

        /// <summary>
        /// Describes whether cool down has ended for this interactable.
        /// </summary>
        /// <returns>If the current time - the last used time >= the cool down amount.</returns>
        public bool IsCoolDownEnded()
        {
            return Time.time - _mLastUse >= coolDown;
        }
    }
}