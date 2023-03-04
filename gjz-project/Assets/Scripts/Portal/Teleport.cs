using UnityEngine;

namespace Portal
{
    /// <summary>
    /// Teleport třída. Obsahuje destinaci pro hráče.
    /// </summary>
    public class Teleport : MonoBehaviour
    {
        public GameObject targetPortal;

        public void ActivatePortal()
        {
            Destroy(targetPortal);
            Destroy(gameObject);
        }
    }
}