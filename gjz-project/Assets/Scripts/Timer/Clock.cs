using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Timer
{
    /// <summary>
    /// Časovač, který počítá od začátku hry a zobrazuje čas v textovém poli.
    /// </summary>
    public class Clock : MonoBehaviour
    {
        private float time = 0;
        public TMP_Text timeText;

        private void Update()
        {
            time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
