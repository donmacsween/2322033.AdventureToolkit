// Author  : Don MacSween
// Purpose : This class spawns a player prefab into the scen on request 

// Included namespaces
using UnityEngine;

namespace ADVTK
{
    public class SpawnPlayer : MonoBehaviour
    {
        #region Fields
        // Seralized     Accessor   Datatype   Name             Initial value 
        [SerializeField] private    GameObject player           = null;
        [SerializeField] private    Transform  spawnPosition    =null;
        #endregion

        #region - Unity MonoBehaviour Methods
        private void Awake()
        {
            // Validate Fields
            // ensure a player prefab has been set
            if (player == null)
            {
                Debug.LogError("Player Prefab not set on " + this.gameObject.name);
            }
            // ensure a transform has been set
            if (spawnPosition == null) 
            { 
                // or default it to this objects tranform
                spawnPosition = this.gameObject.transform; 
            }
        }
        #endregion

        #region - Public Methods
        /// <summary>
        ///  Spawns the player from an external call
        /// </summary>
        public void Spawn()
        {
            Debug.Log("Got here");
            // double check we have a prefab
            if (player != null)
            {
                // instantiate the player into the scene
                Instantiate(player,spawnPosition);
            }
        }
        #endregion
    }
}