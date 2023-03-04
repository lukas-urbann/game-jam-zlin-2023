using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class Pause : MonoBehaviour
    {
        public static Pause Instance;
        private bool pause = false;
        public GameObject pauseMenu;
        
        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            if(pauseMenu.activeSelf)
                pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SwitchPauseState();
            }
        }

        public void SwitchPauseState()
        {
            pause = !pause;
            if (pause) PauseOn(); else PauseOff();
        }

        private void PauseOn()
        {
            pauseMenu.SetActive(true);

            Time.timeScale = 0;
        }

        private void PauseOff()
        {
            pauseMenu.SetActive(false);
            
            Time.timeScale = 1;
        }
    }
}
