using System;
using System.Collections;
using System.Collections.Generic;
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

            float spdx = speed * Input.GetAxis("Vertical");
            float spdy = spdZ * Input.GetAxis("Horizontal");
            
            moveDirection = (forward * spdx) + (right * spdy);
            
            CheckGravity();
            
            characterController.Move(moveDirection * Time.deltaTime);
        }

        private void CheckGravity()
        {
            float movementDirectionY = moveDirection.y;
            
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
        }
    }
}
