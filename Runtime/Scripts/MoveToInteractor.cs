using UnityEngine;

public class MoveToInteractor : MonoBehaviour
{
    [SerializeField] private CharacterMotor characterMotor;
    [SerializeField] private Transform target;

    private void Awake()
    {
        characterMotor = FindFirstObjectByType<CharacterMotor>();
    }

    public void MoveToInteraction()
    {
        if (characterMotor != null)
        {
            characterMotor.MoveTo(target.position);
        }
        else
        {
            characterMotor = FindFirstObjectByType<CharacterMotor>();
            characterMotor.MoveTo(target.position);
        }
    }
}
