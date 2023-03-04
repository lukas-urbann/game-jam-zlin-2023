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
            var position = transform.position;
            position = new Vector3(
                Mathf.Lerp(position.x, Controller.Instance.GetSelectedPlayer().gameObject.transform.position.x, 2 * Time.deltaTime),
                Mathf.Lerp(position.y, Controller.Instance.GetSelectedPlayer().gameObject.transform.position.y, 2 * Time.deltaTime),
                Mathf.Lerp(position.z, Controller.Instance.GetSelectedPlayer().gameObject.transform.position.z, 2 * Time.deltaTime)
                );
            transform.position = position;
        }
    }
}
