using Manager;
using UI;

namespace Menu
{
    /// <summary>
    /// Tlačítko, které přepíná ze hry do menu.
    /// </summary>
    public class ExitToMenu : Button
    {
        public override void ButtonAction()
        {
            //Načte menu
            SceneLoader.Instance.LoadSceneWithAnimation("Menu");
        }
    }
}
