// Interactable.cs
// 07-20-2022
// James LaFritz

using CoreFramework.Attributes;
using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoreFramework
{
    /// <summary>
    /// A <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a> that
    /// can be interacted with.
    /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    public abstract class Interactable : DebugMonoBehaviour
    {
        /// <summary>
        /// Is this a one time use interactable?
        /// </summary>
        [SerializeField] protected bool isOneShot;

        /// <summary>
        /// The amount of time it takes for this interactable to cool down before it can be used again.
        /// </summary>
        [SerializeField]
        [ShowIfBool("isOneShot", false)]
        protected float coolDown;

        /// <summary>
        /// The tag of the GameObject that can interact with this item.
        /// </summary>
        [FormerlySerializedAs("interactTag")] [SerializeField, Tag, InfoBox("The tag of the Object that can interact with this")]
        private string _interactTag = "Player";

        /// <summary>
        /// The Game Event that gets raised when this object is interacted with.
        /// </summary>
        [SerializeField] private GameObjectGameEvent _onInteractGameEvent;

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
        private float _lastUse;

        /// <summary>
        /// Describes whether this interactable can be interacted with.
        /// </summary>
        /// <returns>True if the Interactable can be interacted with.</returns>
        public bool CanInteract
        {
            get
            {
                if (!canUse) return false;
                if (isOneShot && isActivated) return false;
                return IsCoolDownEnded;
            }
        }

        /// <summary>
        /// Describes whether cool down has ended for this interactable.
        /// </summary>
        /// <returns>If the current time - the last used time >= the cool down amount.</returns>
        public bool IsCoolDownEnded => Time.time - _lastUse >= coolDown;

        #region Unity Methods

        /// <summary>
        /// Sent when another object enters a trigger collider attached to this object (2D physics only).
        /// If the other tag is the interact tag will call Interact.
        /// </summary>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(_interactTag)) return;

            Interact();
        }

        /// <summary>
        /// When a GameObject collides with another GameObject, Unity calls OnTriggerEnter.
        /// If the other tag is the interact tag will call Interact.
        /// </summary>
        /// <param name="other">The other</param>
        private void OnTriggerEnter(Collider other)
        {
            Info($"Colliding with {other.name} that has a tag of {other.tag}");
            if (!other.CompareTag(_interactTag)) return;

            Interact();
        }

        #endregion

        /// <summary>
        /// Interact with this interactable.
        /// </summary>
        public void Interact()
        {
            if (!CanInteract)
                return;

            _lastUse = Time.time;
            isActivated = true;
            
            OnInteract();
        }

        public virtual void OnInteract()
        {
            //Info("Raising Game Event");
            if (_onInteractGameEvent) _onInteractGameEvent.Raise(gameObject);
        }
    }
}