using UI;
using UnityEngine;

namespace Menu
{
    public class Maximize : Button
    {
        public override void ButtonAction()
        {
            Screen.fullScreen = !Screen.fullScreen;
            
            if(!Screen.fullScreen)
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
            else
                Screen.SetResolution(800, 600, FullScreenMode.Windowed);
        }
    }
}
