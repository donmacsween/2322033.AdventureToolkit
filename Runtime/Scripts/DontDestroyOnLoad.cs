// Author  : Don MacSween
// Purpose : Prevents the gameobject this script is attached to 
//           being destroyed when a scene loads

// Included namespaces
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    #region - Unity MonoBehaviour Methods
    private void Awake()
    {
        // does what it says
        DontDestroyOnLoad(this);
    }
    #endregion
}
