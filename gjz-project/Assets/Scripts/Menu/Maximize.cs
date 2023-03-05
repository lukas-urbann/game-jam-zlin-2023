using UnityEngine;
using UI;

namespace Menu
{
    /// <summary>
    /// Čudlík co dovolí hráči hru dát do okna či na fullscreen.
    /// </summary>
    public class Maximize : Button
    {
        public override void ButtonAction()
        {
            Screen.fullScreen = !Screen.fullScreen;
            
            //Přepíná i resolution
            if(!Screen.fullScreen)
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
            else
                Screen.SetResolution(800, 600, FullScreenMode.Windowed);
        }
    }
}
