using Manager;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    /// <summary>
    /// Tlačítko, které přepíná ze hry do menu.
    /// </summary>
    public class ExitToMenu : Button
    {
        public override void ButtonAction()
        {
            SceneLoader.Instance.LoadSceneWithAnimation("Menu");
        }
    }
}
