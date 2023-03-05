using System.Collections;
using Camera;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// PlayerType se uvádí při interakcích, aby šlo odhadnout který hráč může s interakcí pracovat.
    /// </summary>
    public enum PlayerType
    {
        Player1,
        Player2
    }

    /// <summary>
    /// Hlavní hráčův skript, který kontroluje obě hráčova těla.
    /// </summary>
    public class Controller : MonoBehaviour
    {
        #region Attributy

        public static Controller Instance;
        
        [Header("PlayerPrefabs")]
        [SerializeField] private Body selectedPlayer;
        public Body player1, player2;
        private float switchTime = 3f;
        private bool canSwitch = true;

        #endregion
        
        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        /// <summary>
        /// Vrací skript 'Body' vybraného hráče.
        /// </summary>
        /// <returns>Vybraný hráč (Body.cs)</returns>
        public Body GetSelectedPlayer()
        {
            return selectedPlayer;
        }

        private void Update()
        {
            //Vymění zvolené tělo hráče
            if (Input.GetAxis("Interaction") > 0 && canSwitch) //Tohle je dělané přes starý input manager
                StartCoroutine(SwitchCooldown());
        }

        private IEnumerator SwitchCooldown()
        {
            canSwitch = false;
            SwitchBodies();
            yield return new WaitForSeconds(switchTime);
            canSwitch = true;
        }

        /// <summary>
        /// Vymění těla hráči
        /// </summary>
        public void SwitchBodies()
        {
            player1.SetCanMove(!player1.GetCanMove());
            player2.SetCanMove(!player2.GetCanMove());

            POVChanger.Instance.camera1.enabled = player1.GetCanMove();
            POVChanger.Instance.camera2.enabled = player2.GetCanMove();

            selectedPlayer = selectedPlayer == player1 ? player2 : player1; //Muj mozek objevil nove univerzum
            
        }
    }
}