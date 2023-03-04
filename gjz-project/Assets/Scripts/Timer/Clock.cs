using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Timer
{
    public class Clock : MonoBehaviour
    {
        private float time = 0;
        public TMP_Text timeText;

        private void Update()
        {
            time += 1 * Time.deltaTime;

            timeText.text = (Math.Floor(time / 60)).ToString("F0") + ":" + (time % 60).ToString("F0");
        }
    }
}
