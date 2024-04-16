// Author  : Don MacSween.
// Purpose : A controller for processing dialog and actions in dialog
using System.Collections;
using UnityEngine;

namespace ADVTK
{
    // Define the types of actions availablie in game - extendable if required
    public enum actionTypes 
                {
                showNextDialog,
                setNPCDialog,
                exitDialog,
                setFlagTrue,
                setFlagFalse,
                removeFlag,
                giveItem,
                takeItem,
                executeCustomScript
                }

    public class DialogManager : MonoBehaviour
    {
        public static DialogManager Instance { get; private set; }

        [SerializeField] private DialogDisplay  dialogDisplay;
                         private NPCDialog      npcDialog;

        private void Awake()
        {
            // field validation of esential components 
            if (dialogDisplay == null)
            {
                // Warn the developer as FindAnyObjectByType is very slow.
                Debug.LogWarning("DialogDisplay not allocated to Dialog Manager");
                dialogDisplay = FindAnyObjectByType<DialogDisplay>();
                if (dialogDisplay == null)
                {
                    Debug.LogError("DialogDisplay not found in scene!");
                }
            }
            EnforceSingleton();
        }

        private void EnforceSingleton()
        {
            // if there is already an instance of this destroy this object
            if (Instance != null && Instance != this)
            { Destroy(this); }
            // otherwise set the instance to this object
            else { Instance = this; }
        }

        /// <summary>
        /// This method is called by the NPCDialog.cs or showNextDialog method
        ///  and processed the passed dialog.
        /// </summary>
        /// <param name="caller">the originating NPCDialog script</param>
        /// <param name="dialog">the dialog to be processes</param>
        public void ProcessDialog(NPCDialog caller, DialogSO dialog)
        {
            // Please view the DialogSO.cs for details of the fields used.
            // The NPC script calling the manager.
            npcDialog = caller;
            // if the dialog ui is hidden show it
            if(!dialogDisplay.gameObject.activeSelf) { dialogDisplay.gameObject.SetActive(true); }
            
            // if the dialog has a condition then...
            if (dialog.isConditional)
            {
                Debug.Log("Conditional");
                // Check to see if the condition is true or false
                if (FlagManager.Instance.CheckFlag(dialog.flagToCheck))
                {
                    // if true process that dialog
                    ProcessDialog(caller, dialog.conditionalTrueDialog);
                }
                else
                {
                    // if false process the other
                    ProcessDialog(caller, dialog.conditionalFalseDialog);
                }
            }
            // if unconditional..
            else
            {
                // ...send the selected dialog to the display
                dialogDisplay.SetDialog(caller, dialog);
            }
        }
        /// <summary>
        /// Called from a ResponseButtonAction when the button is clicked
        /// and then processes the array of actions to be completed
        /// </summary>
        /// <param name="actions">an array of actions</param>
        public void ProcessActions(ActionSO[] actions)
        {
            // if there are actions, start processing them
            if (actions.Length > 0) { StartCoroutine(IProcessActions(actions)); }
        }
        /// <summary>
        /// A coroutine is used to process actions so as not to block the main thread
        /// </summary>
        /// <param name="actions">an array of actions</param>
        /// <returns></returns>
        private IEnumerator IProcessActions(ActionSO[] actions)
        {
            foreach (var action in actions)
            {
                DoAction(action);
            }
            yield return null;
        }

        /// <summary>
        /// Processes an individual action from the array being processed in IProcessActions
        /// checking the type of action to be performed and executing the appropriate method
        /// passing the correct parameters from the action.
        /// </summary>
        /// <param name="action"></param>
        private void DoAction(ActionSO action)
        {
            switch (action.actionType)
            {
                case actionTypes.showNextDialog:
                    ShowNextDialog(action.dialog);
                    break;
                case actionTypes.setNPCDialog:
                    npcDialog.currentDialog = action.dialog;
                    break;
                case actionTypes.exitDialog:
                    dialogDisplay.gameObject.SetActive(false);
                    break;
                case actionTypes.setFlagTrue:
                    Debug.Log("flagTrue" + action.flag);
                    FlagManager.Instance.SetFlag(action.flag, true);
                    break;
                case actionTypes.setFlagFalse:
                    Debug.Log("flagFalse" + action.flag);
                    FlagManager.Instance.SetFlag(action.flag, false);
                    break;
                case actionTypes.removeFlag:
                    Debug.Log("Remove" + action.flag);
                    FlagManager.Instance.RemoveFlag(action.flag);
                    break;
                case actionTypes.giveItem:
                    Debug.Log("itemGiven" + action.item.name);
                    InventoryManager.Instance.RemoveItemFromInventory(action.item);
                    break;
                case actionTypes.takeItem:
                    InventoryManager.Instance.AddItemToInventory(action.item);
                    Debug.Log("itemTaken" + action.item.name);
                    break;
                case actionTypes.executeCustomScript:
                    npcDialog.ExecuteCustomEvents();
                    break;
            }
            // The types of action your game requires can be extended here
        }

        private void ShowNextDialog(DialogSO dialog)
        {
            ProcessDialog(npcDialog, dialog);
        }
    }
}