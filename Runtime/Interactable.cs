#region Header
// Interactable.cs
// Author: James LaFritz
// Description: Base class for Unity GameObjects that can be interacted with in the game environment. 
// This class provides functionality for handling interactions, including one-time use, cooldown periods, and event triggering.
// It is designed to be extended by specific interactable components in the game.
#endregion

using CoreFramework.Attributes;
using CoreFramework.Extensions;
using CoreFramework.ScriptableObjectArchitecture.Events;
using UnityEngine;

namespace CoreFramework
{
    /// <summary>
    /// Base <a href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.html">UnityEngine.MonoBehavior</a>
    /// for <a href="https://docs.unity3d.com/ScriptReference/GameObject.html">Unity GameObjects</a>
    /// that can be interacted with in the game environment.
    /// <p>
    /// Provides functionality for handling interactions, including one-time use, cooldown periods, and event triggering.
    /// Designed to be extended by specific interactable components in the game.
    /// </p>
    /// </summary>
    [HelpURL("https://jameslafritz.github.io/CoreFramework2022/api/CoreFramework.Interactable.html")]
    public abstract class Interactable : MonoBehaviour
    {
        /// <summary>
        /// Indicates whether to show debug information.
        /// </summary>
        [SerializeField] protected bool ShowDebugInfo;
        
        /// <summary>
        /// Determines if this is a one-time-use interactable.
        /// </summary>
        [SerializeField] protected bool IsOneShot;

        /// <summary>
        /// The cooldown time in seconds for this interactable to become usable again.
        /// </summary>
        [SerializeField]
        [ShowIfBool("IsOneShot", false)]
        protected float CoolDown;

        /// <summary>
        /// The tag of the GameObject that can interact with this item.
        /// </summary>
        [SerializeField, Tag, InfoBox("The tag of the Object that can interact with this")]
        private string _interactTag = "Player";

        /// <summary>
        /// The Game Event that gets raised when this object is interacted with.
        /// </summary>
        [SerializeField] private GameObjectGameEvent _onInteractGameEvent;

        /// <summary>
        /// Indicates if this interactable has been activated.
        /// </summary>
        [SerializeField, ReadOnly] protected bool IsActivated;

        /// <summary>
        /// Determines whether this interactable can be used.
        /// </summary>
        [SerializeField, ReadOnly] protected bool CanUse = true;

        /// <summary>
        /// The time that this interactable was last used.
        /// </summary>
        private float _lastUse;

        /// <summary>
        /// Indicates whether this interactable can be interacted with.
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
        /// Indicates whether the cooldown period has ended for this interactable.
        /// </summary>
        /// <returns>True if the cooldown has ended.</returns>
        public bool IsCoolDownEnded => Time.time - _lastUse >= CoolDown;

        #region Unity Methods

        /// <summary>
        /// Called when another object enters a trigger collider attached to this object (2D physics only).
        /// If the other object has the specified tag, it triggers the Interact method.
        /// </summary>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(_interactTag)) return;

            Interact();
        }

        /// <summary>
        /// When a GameObject collides with another GameObject, Unity calls OnTriggerEnter.
        /// If the other object has the specified tag, it triggers the Interact method.
        /// </summary>
        /// <param name="other">The collider of the other object.</param>
        private void OnTriggerEnter(Collider other)
        {
            this.Info($"Colliding with {other.name} that has a tag of {other.tag}", ShowDebugInfo);
            if (!other.CompareTag(_interactTag)) return;

            Interact();
        }

        #endregion

        /// <summary>
        /// Interacts with this interactable, triggering relevant actions.
        /// </summary>
        public void Interact()
        {
            if (!CanInteract)
                return;

            _lastUse = Time.time;
            IsActivated = true;
            
            OnInteract();
        }

        /// <summary>
        /// Callback method triggered when the interactable is interacted with.
        /// </summary>
        public virtual void OnInteract()
        {
            //Info("Raising Game Event");
            if (_onInteractGameEvent) _onInteractGameEvent.Raise(gameObject);
        }
    }
}