using Player;
using UnityEngine;

namespace Menu
{
    /// <summary>
    /// Tlačítko zastaví hru a ukáže menu.
    /// </summary>
    public class Pause : MonoBehaviour
    {
        public static Pause Instance;
        private bool pause = false;
        
        //Fyzický objekt pauzové menu
        public GameObject pauseMenu;
        
        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            if (pauseMenu == null)
            {
                ErrorReporter.ReportError(gameObject, "Chybí reference na objekt", this, "Musí se do pauzy přiřadit pause menu.");
                return;
            }
            
            //Pokud je zaplé při startu, tak to vypneme
            if(pauseMenu.activeSelf)
                pauseMenu.SetActive(false);
        }

        private void Update()
        {
            //Dovolíme pauzovat hru jen při stisku escapu a při hrané hře
            if (Input.GetKeyDown(KeyCode.Escape) && !GameOver.Instance.GetGameOverState())
                SwitchPauseState();
        }

        public void SwitchPauseState()
        {
            //Přepnutí stavu
            
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
