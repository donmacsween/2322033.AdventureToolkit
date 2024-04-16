// Author  : Don MacSween.
// Purpose : Part of the interaction system that moves the player
//           into interaction range
using UnityEngine;
namespace ADVTK
{
    public class MoveToInteractor : MonoBehaviour
    {
        [SerializeField] private CharacterMotor characterMotor;
        [SerializeField] private Transform target;

        private void Awake()
        {
            characterMotor = FindFirstObjectByType<CharacterMotor>();
        }

        /// <summary>
        /// Moves the player to the target world point 
        /// </summary>
        public void MoveToInteraction()
        {
            if (characterMotor != null)
            {
                characterMotor.MoveTo(target.position);
            }
            else
            {
                // there should only ever be one CharacterMotor in the scene
                characterMotor = FindFirstObjectByType<CharacterMotor>();
                characterMotor.MoveTo(target.position);
            }
        }
    }
}
