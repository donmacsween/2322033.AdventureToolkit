using UnityEngine;

public class MazeController : MonoBehaviour
{
    public  float rotationSpeed     = 15f; // Adjust this value for control sensitivity
    private float currentZRotation  = 0f;
    private float inputRotation     = 0f;
        
    void Update()
    {   
    currentZRotation += -inputRotation * rotationSpeed * Time.deltaTime;
    transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }
    public void ChangeRotation(float rotationDelta)
    {
        inputRotation = rotationDelta;
    }
}
