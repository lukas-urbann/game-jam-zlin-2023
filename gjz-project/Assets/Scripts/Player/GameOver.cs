using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GameOver : MonoBehaviour
    {
        public static GameOver Instance;
        private bool gameOverState = false;
        public GameObject gameOverScreen;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
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

        public void GameEnd()
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
