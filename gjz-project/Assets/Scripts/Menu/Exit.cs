using UI;

namespace Menu
{
    /// <summary>
    /// Exit tlačítko vypíná hru. Tečka.
    /// </summary>
    public class Exit : Button
    {
        //Vypne hru, nebo vypne play mode. Zděděno z Button classy.
        public override void ButtonAction()
        {
            //Specialni kouzelny trik pro specialni deti
            //Vypne hru nebo play mode pokud je hra spuštněna v unity editoru
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                 Application.Quit();
            #endif
        }
    }
}
