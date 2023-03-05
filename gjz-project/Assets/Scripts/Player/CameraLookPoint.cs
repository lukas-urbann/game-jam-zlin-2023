using UnityEngine;

namespace Player
{
    /// <summary>
    /// Kalkuluje bod na který se kamera díva.
    /// </summary>
    public class CameraLookPoint : MonoBehaviour
    {
        private void Update()
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, Player.Controller.Instance.GetSelectedPlayer().gameObject.transform.position.x, 2 * Time.deltaTime),
                Mathf.Lerp(transform.position.y, Player.Controller.Instance.GetSelectedPlayer().gameObject.transform.position.y, 2 * Time.deltaTime),
                Mathf.Lerp(transform.position.z, Player.Controller.Instance.GetSelectedPlayer().gameObject.transform.position.z, 2 * Time.deltaTime)
                );
        }
    }
}
