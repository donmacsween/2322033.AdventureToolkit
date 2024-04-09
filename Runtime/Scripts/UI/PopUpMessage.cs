
using UnityEngine;
using TMPro;

namespace ADVTK
{
    public class PopUpMessage : MonoBehaviour
    {
        [SerializeField] private GameObject PopUpPanel = null;
        [SerializeField] private TMP_Text PopUpText = null;
        [SerializeField] private float duration = 4f;

        public static PopUpMessage Instance { get; private set; }

        private void Awake()
        {
            EnforceSingleton();
            PopUpPanel.SetActive(false);
            HideMessage();
        }
        private void EnforceSingleton()
        {
            // if there is already an instance of this destroy this object
            if (Instance != null && Instance != this)
            { Destroy(this); }
            // otherwise set the instance to this object
            else { Instance = this; }
        }

        public void ShowMessage(string message)
        {
            PopUpText.text = message;
            PopUpPanel.SetActive(true);
            Invoke("HideMessage", duration);
        }
        public void HideMessage()
        {
            PopUpPanel.SetActive(false);
        }

    }
}
