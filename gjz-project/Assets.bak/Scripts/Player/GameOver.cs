using UnityEngine;

namespace Player
{
    public class GameOver : MonoBehaviour
    {
        public static GameOver Instance;
        
        //Potřeba dosadit gameover screen, aby se mělo co přehrát
        public GameObject gameOverScreen;
        
        private bool gameOverState = false;

        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Start()
        {
            if(gameOverScreen == null)
                ErrorReporter.ReportError(gameObject, "Nedosazený objekt", this, "Musí se dosadit Game Over Screen");
        }

        public bool GetGameOverState()
        {
            return gameOverState;
        }

        /// <summary>
        /// Ukončí hru, zastaví čas a přehraje animaci.
        /// </summary>
        public void GameEnd()
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
