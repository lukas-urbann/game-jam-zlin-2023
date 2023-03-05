using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class Catcour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Player.GameOver.Instance.GameEnd();
                Time.timeScale = 0;
            }
        }
    }
}
