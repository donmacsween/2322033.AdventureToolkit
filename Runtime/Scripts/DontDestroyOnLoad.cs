// Author  : Don MacSween
// Purpose : A helper script that prevents the gameobject this script is attached to 
//           from being destroyed when a scene loads

// Included namespaces
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // does what it says
        DontDestroyOnLoad(this);
    }
}
