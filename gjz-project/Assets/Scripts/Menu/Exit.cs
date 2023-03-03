using UI;
using System;
using UnityEngine;
using System.Collections;

public class Exit : Button
{
    //Vypne hru, nebo vypne play mode
    public override void ButtonAction()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}