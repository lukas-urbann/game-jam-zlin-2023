using Manager;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class ExitToMenu : Button
    {
        public override void ButtonAction()
        {
            SceneLoader.Instance.LoadSceneWithAnimation("Menu");
        }
    }
}
