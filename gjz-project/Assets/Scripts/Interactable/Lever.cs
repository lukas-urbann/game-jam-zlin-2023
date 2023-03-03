using UnityEngine;
///TODO: DĚDIT Z INTERACTABLE
namespace Interactable
{
    /// <summary>
    /// Základní třída pro páčku. 
    /// </summary>
    public class Lever : MonoBehaviour
    {
        //Distance je vzdálenost páčky ke hráči
        [SerializeField] private float distance;
        [SerializeField] private float reachDistance;

        private bool canInteract = false;
        
        private void Update()
        {
            CheckDistance();
        }

        private void CheckDistance()
        {
            //Kalkulace vzdálenosti zvoleného hráče a páčky
            distance = Vector3.Distance(Player.Controller.Instance.GetSelectedPlayer().transform.position, transform.position);

            //Pokud je hráč blízko, tak může interaktovat
            if (distance <= reachDistance)
                canInteract = true;
            else
                canInteract = false;
        }
    }
}
