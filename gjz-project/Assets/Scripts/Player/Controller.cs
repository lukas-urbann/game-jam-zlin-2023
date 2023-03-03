using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        public static Controller Instance;
        
        [Header("PlayerPrefabs")]
        [SerializeField] private Body selectedPlayer;
        [SerializeField] private Body player1, player2;
        [SerializeField] private GameObject cameraLookPoint;

        public UnityEngine.Camera cam;

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

        public Body GetSelectedPlayer()
        {
            return selectedPlayer;
        }

        private void CalculateInterpolatedLocation()
        {
            cam.transform.LookAt(cameraLookPoint.transform);
        }

        private void Update()
        {
            CalculateInterpolatedLocation();
            
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
    }
}