// Author  : Don MacSween
// Purpose : This class validates a pointer click position against a layer and 
//           invoke the CharacterMotor when required

// Included namespaces
using UnityEngine;
using UnityEngine.InputSystem;

namespace ADVTK
{
    [RequireComponent(typeof(CharacterMotor))]
    public class InputManager : MonoBehaviour
    {
        // using _ to disambiguate
        [SerializeField] private Camera _camera;
        [SerializeField] private int layerNumber = 7;
        private CharacterMotor characterMotor;
        private Ray ray;
        private RaycastHit hit;

        void Awake()
        {
            // validate fields
            if (_camera == null) { _camera = Camera.main; }
            // get reference to CharacterMotor
            characterMotor = gameObject.GetComponent<CharacterMotor>();
        }

        /// <summary>
        /// Called when the pointer click is activated to validate and invoke the CharacterMotor
        /// </summary>
        /// <param name="context">A Unity datatype containg imput data</param>
        public void PointerSelect(InputAction.CallbackContext context)
        {
            if (context.phase.ToString() == "Started")
            {
                ray = _camera.ScreenPointToRay(Pointer.current.position.value);

                if (Physics.Raycast(ray, hitInfo: out hit))
                {
                    Debug.Log("clicked" + hit.collider.gameObject.layer.ToString());
                    if (hit.collider.gameObject.layer == layerNumber) { characterMotor.MoveTo(hit.point); }
                }
            }
        }
    }
}

 