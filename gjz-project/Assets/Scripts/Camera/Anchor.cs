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
        
        private void Update()
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, target.transform.position.x, 2 * Time.deltaTime),
                Mathf.Lerp(transform.position.y, target.transform.position.y, 2 * Time.deltaTime),
                Mathf.Lerp(transform.position.z, target.transform.position.z, 2 * Time.deltaTime)
                );
        }
    }
}
