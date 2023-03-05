using Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class VictoryScreen : MonoBehaviour
    {
        public AudioClip win;
        public Transform player1;
        public Transform player2;
        public GameObject victoryScreen;

        void Update()
        {
            if (Vector3.Distance(player1.position, player2.position) < 1f)
            {
                Audio.Instance.PlaySoundOneShot(win);
                victoryScreen.SetActive(true);
                Debug.Log("Game Over - Victory");
            }
        }
    }
}

