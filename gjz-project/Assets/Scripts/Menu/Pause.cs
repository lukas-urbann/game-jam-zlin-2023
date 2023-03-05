using Player;
using UnityEngine;

namespace Menu
{
    /// <summary>
    /// Tlačítko zastaví hru.
    /// </summary>
    public class Pause : MonoBehaviour
    {
        public static Pause Instance;
        private bool pause;
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
            if (Input.GetKeyDown(KeyCode.Escape) && !GameOver.Instance.GetGameOverState())
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
