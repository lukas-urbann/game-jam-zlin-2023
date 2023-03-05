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
            if (collision.gameObject.CompareTag("Player"))
                Player.GameOver.Instance.GameEnd();
        }
    }
}
