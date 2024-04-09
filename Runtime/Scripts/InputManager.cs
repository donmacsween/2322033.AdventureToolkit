// Author  : Don MacSween
// Purpose : This class 

// Included namespaces
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterMotor))]
public class InputManager : MonoBehaviour
{
    // using _ to disambiguate
    [SerializeField] private Camera         _camera;
    [SerializeField] private LayerMask      ignoreLayer;
                     private CharacterMotor characterMotor;
                     private Ray            ray;
                     private RaycastHit     hit;

    
    void Awake()
    {
        // validate fields
        if (_camera == null) { _camera = Camera.main; }
        // get reference to CharacterMotor
        characterMotor = gameObject.GetComponent<CharacterMotor>();
    }

    public void PointerSelect(InputAction.CallbackContext context)
    {

        if (context.phase.ToString() == "Started")
            Debug.Log("click");
        {
            ray = _camera.ScreenPointToRay(Pointer.current.position.value);
            
            if (Physics.Raycast(ray, hitInfo: out hit) )
            {
                    Debug.Log("clicked" + hit.collider.gameObject.layer.ToString());

                if (hit.collider.gameObject.layer == 7 ) { characterMotor.MoveTo(hit.point); }
            }
        }
    }
}

 