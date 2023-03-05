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
            var position = transform.position;
            position = new Vector3(
                Mathf.Lerp(position.x, target.transform.position.x, speed * Time.deltaTime),
                Mathf.Lerp(position.y, target.transform.position.y, speed * Time.deltaTime),
                Mathf.Lerp(position.z, target.transform.position.z, speed * Time.deltaTime)
                );
            transform.position = position;
        }
    }
}
