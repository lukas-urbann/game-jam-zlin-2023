using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GameOver : MonoBehaviour
    {
        public static GameOver Instance;
        
        //Potřeba dosadit gameover screen, aby se mělo co přehrát
        public GameObject gameOverScreen;
        
        private bool gameOverState = false;

        public Sprite player1Lose, player2Lose;

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
        public void GameEnd(bool player1)
        {
            Image img = gameOverScreen.GetComponent<Image>();

            if (player1)
                img.sprite = player1Lose;
            else
                img.sprite = player2Lose;
            //Player one je startovací charakter
            //gameOverScreen.SetActive(true);
            //Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }
}
