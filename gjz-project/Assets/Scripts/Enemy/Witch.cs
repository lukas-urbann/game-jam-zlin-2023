using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Čarodějnice má podobně jako kočka jisté predefinované cesty, kterými prolítává.
    /// Pod sebou má raycast, který při zásahu hráče zabije.
    /// </summary>
    public class Witch : MonoBehaviour
    {
        private void FixedUpdate()
        {
            //Base raycast
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                //Kontrola zasažených objektů
                if (hit.collider.CompareTag("Player1")||hit.collider.CompareTag("Player2"))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
                    //Označí zásah a vypne hru
                    Player.GameOver.Instance.GameEnd(hit.collider.CompareTag("Player1"));
                    return;
                }
                
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            }
            else
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
        }
    }
}
