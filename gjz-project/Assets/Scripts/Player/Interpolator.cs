using UnityEngine;

namespace Player
{
    /// <summary>
    /// Ovládá objekt mezi hráči, který následuje kamera pro plynulý přelet.
    /// </summary>
    public class Interpolator : MonoBehaviour
    {
        //Zjednodušení dlouhých  
        private Vector3 Player1Position;
        private Vector3 Player2Position;

        private void Update()
        {
            Player1Position = Controller.Instance.player1.transform.position;
            Player2Position = Controller.Instance.player2.transform.position;

            transform.position = new Vector3(
                Mathf.Lerp(Player2Position.x, Player1Position.x, 0.5f),
                Mathf.Lerp(Player2Position.y, Player1Position.y, 0.5f),
                Mathf.Lerp(Player2Position.z, Player1Position.z, 0.5f)
                );
        }
    }
}
