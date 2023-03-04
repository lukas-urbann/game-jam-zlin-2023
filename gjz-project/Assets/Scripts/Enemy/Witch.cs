using Player;
using UnityEngine;

namespace Enemy
{
    public class Witch : MonoBehaviour
    {
        
        void FixedUpdate()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
                    GameOver.Instance.GameEnd();
                    return;
                }
                
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            }
        }
        

    }
}
