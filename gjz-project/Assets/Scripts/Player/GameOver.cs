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

        public bool GetGameOverState()
        {
            return gameOverState;
        }
    }
}
