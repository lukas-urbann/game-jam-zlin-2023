using Manager;
using UI;

namespace Menu
{
    /// <summary>
    /// Tlačítko pro spuśtění hry
    /// </summary>
    public class Play : Button
    {
        public override void ButtonAction()
        {
            SceneLoader.Instance.LoadSceneWithAnimation("Game");
        }
    }
}