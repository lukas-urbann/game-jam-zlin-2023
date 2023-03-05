using System.Collections;
using Camera;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Hlavní hráčův skript, který kontroluje obě hráčova těla.
    /// </summary>
    public class Controller : MonoBehaviour
    {
        #region Attributy

        public static Controller Instance;
        
        [Header("PlayerPrefabs")]
        [SerializeField] private Body selectedPlayer;
        [Tooltip("Dosazení těl obou hráčů.")]
        public Body player1, player2;
        
        private float switchTime = 1.5f;
        private bool canSwitch = true;

        #endregion
        
        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            //Pokud není žádný zvolený, tak dosadíme
            if (selectedPlayer == null)
            {
                selectedPlayer = player1;
                selectedPlayer.SetCanMove(true);
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

        /// <summary>
        /// Pouze cooldown aby hráč nemohl spamovat změnu těl a odhalit si zbytek mapy.
        /// </summary>
        /// <returns>Nic</returns>
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
            //Vymění těla a jejich schopnost chodit.
            
            player1.SetCanMove(!player1.GetCanMove());
            player2.SetCanMove(!player2.GetCanMove());

            POVChanger.Instance.camera1.enabled = player1.GetCanMove();
            POVChanger.Instance.camera2.enabled = player2.GetCanMove();

            selectedPlayer = selectedPlayer == player1 ? player2 : player1; //Tento if se mi moc líbí
        }
    }
}