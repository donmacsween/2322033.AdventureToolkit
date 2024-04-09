using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ADVTK 
{
    public enum gameStates 
    {
    initalising,
    loading,
    inGame,
    inDialog,
    inMenu,
    }
    public class AdventureManager : MonoBehaviour
    {
        // a singleton reference to this object is used so it can be accessed anywhere in the project;
                         public static AdventureManager Instance;
        [SerializeField] private string firstSceneToLoad;
                         public gameStates currentGameState
                         {
                            get { return this.currentGameState; }
                            set
                            {
                                this.currentGameState = value;
                                onGameStateChange();
                            }
                         }
        
        // Monobehaviour Methods
        private void Awake()
        {
            currentGameState = gameStates.initalising;
            DontDestroyOnLoad(gameObject);
            EnforceSingleton();
        }

        private void Start()
        {
            
        }

        // Private Methods
        private void EnforceSingleton()
        {
            if (Instance != null && Instance != this)
            { Destroy(this); }
            else { Instance = this; }
        }

        private void onGameStateChange()
        {
            switch (currentGameState)
            {
                case gameStates.initalising:
                    //
                    break;
                case gameStates.inMenu:
                    //
                    break;
                case gameStates.loading:
                    //
                    break;
                case gameStates.inGame:
                    //
                    break;
                case gameStates.inDialog:
                    //
                    break;
            }
        }
        // Public Methods
        public void LoadScene(string sceneName) 
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        // Coroutines
        IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncLoad.isDone) { yield return null;}
        }
    }

}