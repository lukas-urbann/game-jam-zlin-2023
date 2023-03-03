using UnityEngine;

namespace Player
{
    /// <summary>
    /// Hlavní třída ovládající jednotlivé těla hráče.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class Body : MonoBehaviour
    {
        #region Attributy

        private CharacterController characterController;
        
        //Označuje hráče
        public PlayerType PlayerType;
        
        //Booly
        [SerializeField] private bool canMove = false;
        [SerializeField] private bool canTeleport = true;

        //Proměnné editovatelné
        [SerializeField] private float speed = 5;
        [SerializeField] private float jumpSpeed = 6;

        //Proměnné private
        private Vector3 moveDirection = Vector3.zero;
        private float gravity = 9.87f;
        
        #endregion
        
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            //Checkuje pohyb
            if (!canMove)
                return;
            
            MoveInput();
            JumpInput();
            Gravity();
            
            characterController.Move(moveDirection * Time.deltaTime); //Hýbe s hráčem
        }

        public void SetCanMove(bool val)
        {
            canMove = val;
        }
        
        public bool GetCanMove()
        {
            return canMove;
        }

        /// <summary>
        /// Dovoluje se hráči hýbat.
        /// </summary>
        private void MoveInput()
        {
            Vector3 playerForward = transform.TransformDirection(Vector3.forward);
            Vector3 playerRight = transform.TransformDirection(Vector3.right);
            
            float bodySpeedX = speed * Input.GetAxis("Vertical");
            float bodySpeedY = speed * Input.GetAxis("Horizontal");
            
            moveDirection = (playerForward * bodySpeedX) + (playerRight * bodySpeedY);
        }

        /// <summary>
        /// Dovoluje hráči skákat.
        /// </summary>
        private void JumpInput()
        {
            //TODO: NĚkde tu je rozbity skok a gravitace
            float moveDirectionYTemp = moveDirection.y;
            
            if (Input.GetButton("Jump") && characterController.isGrounded)
                moveDirection.y = jumpSpeed;
            else
                moveDirection.y = moveDirectionYTemp;
        }

        /// <summary>
        /// Působení gravitace.
        /// </summary>
        private void Gravity()
        {
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                TeleportBody(other.GetComponent<Portal.Teleport>().targetDestination);
                Destroy(other.gameObject);
            }
        }

        
        private void TeleportBody(Transform pos)
        {
            characterController.enabled = false; //Tohle se musí vypnout nebo se hráč neteleportuje, trust me, im an engineer
            transform.position = pos.position;
            characterController.enabled = true;
        }
    }
}
