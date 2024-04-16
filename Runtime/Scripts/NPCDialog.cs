// Author  : Don MacSween.
// Purpose : Stores data on the initial NPC dialog and custom UnityEvents
using UnityEngine;
using UnityEngine.Events;

namespace ADVTK
{
    public class NPCDialog : MonoBehaviour
    {
        [SerializeField] private DialogSO   initialDialog;
                         public  string     npcName;
                         public  DialogSO   currentDialog;
                         public  UnityEvent customEvent;

        private void Awake()
        {
            // Field Validation
            if (initialDialog == null)
            {
                Debug.LogError("Initial NPC Dialog not set on :" + gameObject.name);
            }
            currentDialog = initialDialog;
        }

  
        /// <summary>
        /// Passes the dialog set on this component to the dialog manager for processing
        /// </summary>
        public void StartDialog()
        {
            if (currentDialog != null) 
            {
                Debug.Log("dialog Started");    
                DialogManager.Instance.ProcessDialog(this, currentDialog); 
            
            }
        }

        /// <summary>
        /// If the dialog has a custom event that needs processing do it via external call
        /// </summary>
        public void ExecuteCustomEvents()
        {
            customEvent.Invoke();
        }
    }
}
