using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        [Header("PlayerPrefabs")]
        [SerializeField] private Body selectedPlayer;
        [SerializeField] private Player.Body player1, player2;

        private void AssignObjects()
        {
        }
        
        void Start()
        {
            AssignObjects();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                SwitchBodies();
            }
        }

        public void SwitchBodies()
        {
            selectedPlayer.canMove = false;
            
            if (selectedPlayer == player1)
                selectedPlayer = player2;
            else
                selectedPlayer = player1;

            selectedPlayer.canMove = true;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
        }
    }
}