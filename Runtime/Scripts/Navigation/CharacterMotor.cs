using UnityEngine;
using UnityEngine.AI;

// This script requires these components to function correctly
[RequireComponent(typeof(NavMeshAgent ))]
[RequireComponent(typeof(Animator     ))]
public class CharacterMotor : MonoBehaviour
{
    // The  animator controller attached to this gameobject
    private Animator     playerAnimator;
    private NavMeshAgent agent;
    
    private void Awake()
    {
        // Get references to  the components
        agent           = gameObject.GetComponent<NavMeshAgent>();
        playerAnimator  = gameObject.GetComponent<Animator    >();
    }
    private void Update()
    {
        // change the state of the animator if the player is moving
        if(agent.velocity.magnitude > 0)
        { playerAnimator.SetBool("isWalking", true); }
        else
        { playerAnimator.SetBool("isWalking", false); }
    }
    public void MoveTo(Vector3 position)
    {
        // Set the NavMeshAgents target position when called
        agent.destination = position; 
    }
}
