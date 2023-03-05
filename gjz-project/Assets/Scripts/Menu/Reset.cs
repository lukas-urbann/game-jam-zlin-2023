using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Reset : Button
    {
        public override void ButtonAction()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

