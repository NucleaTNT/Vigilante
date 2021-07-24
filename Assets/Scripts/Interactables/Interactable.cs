using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    protected bool isPlayerInRange = false;
    [SerializeField] protected Emote playerInRangeEmote;
    protected MainInputMap inputMap;

    [Tooltip("OnInteract Events")] public List<UnityEvent> onInteractEvents;

    private void Action(InputAction.CallbackContext ctx) { foreach (UnityEvent e in onInteractEvents) e.Invoke(); }
    
    #region Virtual Methods

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            try 
            {
                other.GetComponent<Player>().EmoteManager.ShowEmote(playerInRangeEmote);
                isPlayerInRange = true; 
            } 
            catch (NullReferenceException)
            {
                Debug.LogError("[Interactable](OnTriggerEnter2D): NullRefExc while showing player emote!");
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        { 
            try
            {
                other.GetComponent<Player>().EmoteManager.HideEmote();
                isPlayerInRange = false;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("[Interactable](OnTriggerExit2D): NullRefExc while showing player emote!");
            }
        }
    }

    #endregion
    
    #region MonoBehaviour Callbacks

    private void OnEnable()
    {
        inputMap.Player.Use.performed += Action;
        inputMap.Player.Use.Enable();
    }

    private void OnDisable()
    {
        inputMap.Player.Use.performed -= Action;
        inputMap.Player.Use.Disable();
    }
    
    private void Awake()
    {
        inputMap = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().MainInputMap;
    }

    #endregion
}
