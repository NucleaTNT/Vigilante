using Dev.NucleaTNT.Vigilante.Interfaces;
using Dev.NucleaTNT.Vigilante.PlayerScripts;
using Dev.NucleaTNT.Vigilante.UI;
using Dev.NucleaTNT.Vigilante.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Dev.NucleaTNT.Vigilante.Interactables 
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        protected bool _isPlayerInRange = false;
        [SerializeField] protected Emote _playerInRangeEmote;
        protected MainInputMap _inputMap;

        protected List<UnityEvent> _onInteractEvents = new List<UnityEvent>();
        public void Interact(InputAction.CallbackContext ctx) { foreach (UnityEvent e in _onInteractEvents) e.Invoke(); }
        
        #region Virtual Methods
    
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            if (other.TryGetComponent<Player>(out Player player)) 
            {
                player.EmoteManager.ShowEmote(_playerInRangeEmote);
                _isPlayerInRange = true; 
            } else Debug.LogError("[Interactable](OnTriggerEnter2D): NullRefExc while showing player emote!");
        }
    
        protected virtual void OnTriggerExit2D(Collider2D other) 
        {
            if (!other.CompareTag("Player")) return;
             
            if (other.TryGetComponent<Player>(out Player player)) 
            {
                player.EmoteManager.HideEmote();
                _isPlayerInRange = false; 
            } else Debug.LogError("[Interactable](OnTriggerEnter2D): NullRefExc while hiding player emote!");
        }
    
        #endregion
        
        #region MonoBehaviour Callbacks
    
        private void OnEnable()
        {
            _inputMap.Player.Use.performed += Interact;
            _inputMap.Player.Use.Enable();
        }
    
        private void OnDisable()
        {
            _inputMap.Player.Use.performed -= Interact;
            _inputMap.Player.Use.Disable();
        }
        
        private void Awake() => _inputMap = GameManager.Instance.MainInputMap;

        #endregion
    }
}
