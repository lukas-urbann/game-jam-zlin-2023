using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Nepřátelská kočka. Akorát kontroluje hitbox hráče a když se tak stane, tak triggerne konec hry.
    /// </summary>
    public class Catcour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player1")||collision.gameObject.CompareTag("Player2"))
                Player.GameOver.Instance.GameEnd(collision.gameObject.CompareTag("Player1"));
        }
    }
}
