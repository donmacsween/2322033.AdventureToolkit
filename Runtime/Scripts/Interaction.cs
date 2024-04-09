// Author : Don MacSween
// Purpose: this script allows the player to interact with various
// objects, NPCs or custom events within your game.
using UnityEngine;
using UnityEngine.Events;

namespace ADVTK
{
    // Defines the types of interactions possible - can be extended to meet custom needs
    public enum InteractionType
    {
    InitiateDialog,
    PickupObject,
    CustomEvent
    }

    public class Interaction : MonoBehaviour
    {
        [SerializeField] private InteractionType    interactionType = 0;
        [SerializeField] private UnityEvent         customEvent;
        [SerializeField] private GameObject         interactionCanvas;
        [SerializeField] private Transform          interactionPosition;
        [SerializeField] private NPCDialog          npcDialog;
        [SerializeField] private ItemSO             inventoryItem;
        //[SerializeField] private InteractableObject InteractableObject;
        [SerializeField] private GameObject         MoveToButton;
        [SerializeField] private GameObject         InteractButton;

        private void Awake()
        {
            if (interactionType == InteractionType.InitiateDialog && npcDialog == null)
            { 
                // This is a very slow call and should really be set in the inspector
                npcDialog = gameObject.GetComponentInParent<NPCDialog>();
                // So warn the developer 
                Debug.LogWarning("npcDialog not set on "+gameObject.name);
            }
        }
        /// <summary>
        ///  Detects when the player enters the interaction zones and swaps buttons
        ///  to show the interact button
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                MoveToButton.SetActive(false);
                InteractButton.SetActive(true);
            }
        }
        // <summary>
        ///  Detects when the player exits the interaction zones and swaps buttons
        ///  to show the move to button
        /// </summary>
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                MoveToButton.SetActive(true);
                InteractButton.SetActive(false);
            }
        }

        /// <summary>
        /// Execute the given interaction type on request
        /// </summary>
        public void ExecuteInteraction()
        {
            switch (interactionType)
            {
                case InteractionType.InitiateDialog:
                    npcDialog.StartDialog();
                    break;
                case InteractionType.PickupObject:
                    if (inventoryItem != null) 
                    {
                        InventoryManager.Instance.AddItemToInventory(inventoryItem);
                        Destroy(transform.parent.gameObject);
                    }
                    else
                    {
                        Debug.LogError("inventoryItem not set on " + this.gameObject.name);
                    }
                    break;
                case InteractionType.CustomEvent:
                    if (customEvent != null)
                    {
                        customEvent.Invoke();
                    }
                    else
                    {
                        Debug.LogError("No custom event set on " + this.gameObject.name);
                    }
                    break;
            }
        }
    }
}
