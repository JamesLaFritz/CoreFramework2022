// Interactable.cs
// 07-20-2022
// James LaFritz

using CoreFramework.Attributes;
using CoreFramework.Extensions;
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
    [HelpURL("https://jameslafritz.github.io/CoreFramework2022/api/CoreFramework.Interactable.html")]
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected bool ShowDebugInfo;
        
        /// <summary>
        /// Is this a one time use interactable?
        /// </summary>
        [SerializeField] protected bool IsOneShot;

        /// <summary>
        /// The amount of time it takes for this interactable to cool down before it can be used again.
        /// </summary>
        [SerializeField]
        [ShowIfBool("IsOneShot", false)]
        protected float CoolDown;

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
        [SerializeField, ReadOnly] protected bool IsActivated;

        /// <summary>
        /// can this interactable be used.
        /// </summary>
        [SerializeField, ReadOnly] protected bool CanUse = true;

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
                if (!CanUse) return false;
                if (IsOneShot && IsActivated) return false;
                return IsCoolDownEnded;
            }
        }

        /// <summary>
        /// Describes whether cool down has ended for this interactable.
        /// </summary>
        /// <returns>If the current time - the last used time >= the cool down amount.</returns>
        public bool IsCoolDownEnded => Time.time - _lastUse >= CoolDown;

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
            this.Info($"Colliding with {other.name} that has a tag of {other.tag}", ShowDebugInfo);
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
            IsActivated = true;
            
            OnInteract();
        }

        public virtual void OnInteract()
        {
            //Info("Raising Game Event");
            if (_onInteractGameEvent) _onInteractGameEvent.Raise(gameObject);
        }
    }
}