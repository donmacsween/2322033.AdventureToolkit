using System.Collections;
using System.Collections.Generic;
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
