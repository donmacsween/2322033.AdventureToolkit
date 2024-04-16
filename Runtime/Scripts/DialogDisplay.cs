// Author  : Don MacSween.
// Purpose : A view component that handles dialog display on a canvas
using UnityEngine;
using TMPro;

namespace ADVTK
{
    public class DialogDisplay : MonoBehaviour
    {
        [Header("Name of NPC")]
        [SerializeField] TMP_Text   npcName;
        [Header("Text spoken by NPC")]
        [SerializeField] TMP_Text   npcDialogText;
        [Header("Buttons used for player response")]
        [SerializeField] GameObject button1;
        [SerializeField] GameObject button2;
        [SerializeField] GameObject button3;
        [SerializeField] GameObject button4;
        [Header("Text Labels on each button")]
        [SerializeField] TMP_Text   button1Text;
        [SerializeField] TMP_Text   button2Text;
        [SerializeField] TMP_Text   button3Text;
        [SerializeField] TMP_Text   button4Text;

        /// <summary>
        /// Copies the data from the DialogSO scriptable object into
        /// the onscreen canvas elements 
        /// </summary>
        /// <param name="caller">The NPC Dialog script containg the NPCs Name</param>
        /// <param name="dialog">The Dialog scriptable object with all the other data needed</param>
        public void SetDialog(NPCDialog caller,DialogSO dialog)
        {
            ClearCanvasElements();
            npcName.text = caller.npcName;
            npcDialogText.text = dialog.unconditionalDialog;
            int m_numberOfResponses = dialog.responses.Length;
            // if there is a response
            if (m_numberOfResponses > 0)
            {             
                    //show the button
                    button1.SetActive(true);
                    // set the text response in the label
                    button1Text.text = dialog.responses[0].response;
                    // transfer the actions to be taken to the ResponseButtonActions script
                    button1.GetComponent<ResponseButtonActions>().actions = dialog.responses[0].actions;
            }

            // if there is a response
            if (m_numberOfResponses > 1)
            {
                    //show the button
                    button2.SetActive(true);
                    // set the text response in the label
                    button2Text.text = dialog.responses[1].response;
                    // transfer the actions to be taken to the ResponseButtonActions script
                    button2.GetComponent<ResponseButtonActions>().actions = dialog.responses[1].actions;
            }
            // if there is a response
            if (m_numberOfResponses > 2)
            {
                    //show the button
                    button3.SetActive(true);
                    // set the text response in the label
                    button3Text.text = dialog.responses[2].response;
                    // transfer the actions to be taken to the ResponseButtonActions script
                    button3.GetComponent<ResponseButtonActions>().actions = dialog.responses[2].actions;
            }
            // if there is a response
            if (dialog.responses.Length > 3)
            {
                    //show the button
                    button4.SetActive(true);
                    // set the text response in the label
                    button4Text.text = dialog.responses[3].response;
                    // transfer the actions to be taken to the ResponseButtonActions script
                    button4.GetComponent<ResponseButtonActions>().actions = dialog.responses[3].actions;
            }

            // the script can be exteded here to cater for more responses if needed

        }
        /// <summary>
        /// Clears the onscreen canvas elements 
        /// </summary>
        private void ClearCanvasElements()
        {
            // empty the text lables
            npcName.text       = string.Empty;
            npcDialogText.text = string.Empty;
            button1Text.text   = string.Empty;
            button2Text.text   = string.Empty;
            button3Text.text   = string.Empty;
            button4Text.text   = string.Empty;
            // hide all the response buttons
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);

        }
    }
}
