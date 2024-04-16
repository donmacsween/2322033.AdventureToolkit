// Author  : Don MacSween.
// Purpose : added to the dialogdisplay prefab to trigger user interactions
//           with the response buttons
using UnityEngine;
using UnityEngine.EventSystems;

namespace ADVTK
{
    public class ResponseButtonActions : MonoBehaviour, IPointerClickHandler
    {
        // Set by the DialogDisplay.cs SetDialog method
        public ActionSO[] actions;
        // When the button is clicked
        public void OnPointerClick(PointerEventData eventData)
        {
            // if it's the left button clicked
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                //process the response buttons actions
                DialogManager.Instance.ProcessActions(actions);
            }
        }
    }
}
