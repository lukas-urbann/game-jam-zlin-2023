using UI;
using UnityEngine.SceneManagement;

namespace Menu
{
    /// <summary>
    /// Tlačítko pro spuśtění hry
    /// </summary>
    public class Play : Button
    {
        public override void ButtonAction()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}