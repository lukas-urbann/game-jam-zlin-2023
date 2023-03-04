using TMPro;
using UnityEngine;

namespace Timer
{
    /// <summary>
    /// Časovač, který počítá od začátku hry a zobrazuje čas v textovém poli.
    /// </summary>
    public class Clock : MonoBehaviour
    {
        private float _time;
        public TMP_Text timeText;

        private void Update()
        {
            _time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_time / 60f);
            int seconds = Mathf.FloorToInt(_time % 60f);
            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
