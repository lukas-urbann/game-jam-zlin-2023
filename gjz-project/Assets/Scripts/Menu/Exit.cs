using UI;
using UnityEditor;

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
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                 Application.Quit();
            #endif
        }
    }
}
