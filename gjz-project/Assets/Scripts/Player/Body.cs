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
        
        //Booly
        [SerializeField] private bool canMove = false;

        //Proměnné editovatelné
        [SerializeField] private float speed = 3;

        //Proměnné private
        public Vector3 moveDirection = Vector3.zero;
        
        #endregion
        
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            BodyMovement();    
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
        /// Dovoluje se hráči hýbat a hlídá input.
        /// </summary>
        private void BodyMovement()
        {
            //Checkuje pohyb
            if (!canMove)
                return;
            
            Vector3 playerForward = transform.TransformDirection(Vector3.forward);
            Vector3 playerRight = transform.TransformDirection(Vector3.right);
            
            float bodySpeedX = speed * Input.GetAxis("Vertical");
            float bodySpeedY = speed * Input.GetAxis("Horizontal");
            
            //Nechame to takhle, může to být "tilované" ale ve finále to působí hůř

            moveDirection = (playerForward * bodySpeedX) + (playerRight * bodySpeedY);

            characterController.Move(moveDirection * Time.deltaTime); //Hýbe s hráčem
        }

        private void OnTriggerEnter(Collider other)
        {
            //Střet s pastí = konec hry
            if (other.gameObject.CompareTag("Trap") && other.GetComponent<Traps.Trap>().canKill)
                GameOver.Instance.GameEnd();
        }
    }
}
