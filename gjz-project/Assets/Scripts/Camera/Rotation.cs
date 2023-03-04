using UnityEngine;

namespace Camera
{
    /// <summary>
    /// Nastavuje cíl, na který se kamera dívá.
    /// </summary>
    public class Rotation : MonoBehaviour
    {
        public Transform target;

        private void Update()
        {
            transform.LookAt(target);
        }
    }
}
