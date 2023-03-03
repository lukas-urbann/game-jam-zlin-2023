using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Interpolator : MonoBehaviour
    {
        public GameObject player1, player2;
        
        private Vector3 Player1Position;
        private Vector3 Player2Position;

        private void Update()
        {
            Player1Position = player1.transform.position;
            Player2Position = player2.transform.position;

            transform.position = new Vector3(
                Mathf.Lerp(Player2Position.x, Player1Position.x, 0.5f),
                Mathf.Lerp(Player2Position.y, Player1Position.y, 0.5f),
                Mathf.Lerp(Player2Position.z, Player1Position.z, 0.5f)
                );
        }
    }
}
