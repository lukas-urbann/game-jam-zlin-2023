using UnityEngine;

namespace Camera
{
    /// <summary>
    /// Kotva pro kameru. Kamera nastavuje svou pozici na mapě díky interpolaci v tomto skriptu.
    /// </summary>
    public class Anchor : MonoBehaviour
    {
        //Target je objekt či transform, jehož pozici kamera následuje.
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        
        private void Update()
        {
            Vector3 targetPosition = target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }

    }
}
