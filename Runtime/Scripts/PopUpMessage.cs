// Author  : Don MacSween.
// Purpose : A simple helper that pops up a prefab message box with a custom message
using UnityEngine;
using TMPro;

namespace ADVTK
{
    public class PopUpMessage : MonoBehaviour
    {
        [SerializeField] private       GameObject PopUpPanel = null;
        [SerializeField] private       TMP_Text   PopUpText  = null;
                         private const float      DURATION   = 4f;
        public static PopUpMessage Instance { get; private set; }

        private void Awake()
        {
            EnforceSingleton();
            PopUpPanel.SetActive(false);
            HideMessage();
        }
        /// <summary>
        /// A singleton so that any class can make use of the helper
        /// </summary>
        private void EnforceSingleton()
        {
            // if there is already an instance of this destroy this object
            if (Instance != null && Instance != this)
            { Destroy(this); }
            // otherwise set the instance to this object
            else { Instance = this; }
        }
        /// <summary>
        /// Shows the message
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            PopUpText.text = message;
            PopUpPanel.SetActive(true);
            Invoke("HideMessage", DURATION);
        }
        /// <summary>
        /// Hides it after the defined time
        /// </summary>
        public void HideMessage()
        {
            PopUpPanel.SetActive(false);
        }
    }
}
