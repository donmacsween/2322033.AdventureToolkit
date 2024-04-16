// Author  : Don MacSween
// Purpose : This class loads a level on request 

// Included namespaces
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ADVTK
{

    public class LoadLevel : MonoBehaviour
    {
        #region Fields
        // Seralized     Accessor   Datatype   Name             Initial value 
        [SerializeField] private    GameObject loadingCanvas    = null;

        #endregion

        #region - Public Methods
        /// <summary>
        ///  Loads a level from an external call
        /// </summary>
        public void loadAsync(string level)
        {
            
            StartCoroutine(LoadYourAsyncScene(level));
        }
        #endregion

        #region - Coroutines
        IEnumerator LoadYourAsyncScene(string level)
        {
            
            // Hide our current scene with an optional loading screen
            if (loadingCanvas != null) { loadingCanvas.SetActive(true); }
            // The Application loads the passed level by string
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);

            // yield until the level is fully loaded
            while (!asyncLoad.isDone)
            {
                yield return null;
                // Reveal our current scene 
                if (loadingCanvas != null) { loadingCanvas.SetActive(false); }
            }
            
        }
        #endregion
    }
}
