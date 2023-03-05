using UnityEngine;

namespace Player
{
    public class BodyModel : MonoBehaviour
    {
        public Animator anim;
        public float rbMagnitude;
        public CharacterController characterController;
        public Body playerBody;
        [SerializeField] private Vector3 direction;
        
        private void LateUpdate()
        {
            if (!playerBody.GetCanMove())
            {
                anim.SetFloat("Blend", 0);
                return;
            }
            
            rbMagnitude = characterController.velocity.magnitude;
            
            anim.SetFloat("Blend", rbMagnitude/3);

            direction = new Vector3(playerBody.moveDirection.x, 0, playerBody.moveDirection.z);

            if (rbMagnitude >= 0.5f)
            {
                transform.rotation = Quaternion.LookRotation(
                    direction,
                    Vector3.up);
            }
        }
    }
}
