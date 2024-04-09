using UnityEngine;
using UnityEngine.Events;

namespace ADVTK
{
    public class NPCDialog : MonoBehaviour
    {
        #region Fields
        [SerializeField] private DialogSO   initialDialog;
                         public  string     npcName;
                         public  DialogSO   currentDialog;
                         public  UnityEvent customEvent;
        #endregion

        #region Unity Private Methods
        private void Awake()
        {
            // Field Validation
            if (initialDialog == null)
            {
                Debug.LogError("Initial NPC Dialog not set on :" + gameObject.name);
            }
            currentDialog = initialDialog;
        }
        #endregion

        #region Public Methods
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
        #endregion
    }
}
