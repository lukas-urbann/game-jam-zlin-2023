using UI;
using System;
using UnityEngine;
using System.Collections;

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
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                 Application.Quit();
            #endif
        }
    }
}
