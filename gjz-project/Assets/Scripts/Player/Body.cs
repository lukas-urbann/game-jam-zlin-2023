using System;
using System.Collections;
using System.Collections.Generic;
using Portal;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Body : MonoBehaviour
    {
        private CharacterController characterController;
        public bool canMove = false;
        
        [SerializeField] private float speed = 5;
        [SerializeField] private float spdZ = 5;
        [SerializeField] private float jumpSpeed = 6;
        [SerializeField] private float gravity = 9.87f;
        public bool canTeleport = true;

        Vector3 moveDirection = Vector3.zero;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (!canMove)
                return;
            
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float movementDirectionY = moveDirection.y;

            float spdx = speed * Input.GetAxis("Vertical");
            float spdy = spdZ * Input.GetAxis("Horizontal");
            
            moveDirection = (forward * spdx) + (right * spdy);
            
            
            if (Input.GetButton("Jump") && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            
            characterController.Move(moveDirection * Time.deltaTime);
        }

        private void CheckGravity()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                canTeleport = false;

                characterController.enabled = false;
                transform.position = other.GetComponent<Teleport>().targetDestination.position;
                characterController.enabled = true;
                Destroy(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                canTeleport = true;
            }
            
            if (other.gameObject.CompareTag("Lever"))
            {
                canTeleport = true;
            }
        }
    }
}
