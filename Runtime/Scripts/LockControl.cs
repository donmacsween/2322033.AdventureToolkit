// Author  : Don MacSween.
// Purpose : A helper script that manages the lock part of the physics puzzle
using UnityEngine;

public class LockControl : MonoBehaviour
{
    [SerializeField]  private  GameObject lockblock;

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            lockblock.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject, .5f);
    }
}
