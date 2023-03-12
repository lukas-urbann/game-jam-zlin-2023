using UnityEngine;

namespace Player
{
    /// <summary>
    /// Hráčovo tělo a model jsou rozdílné věci.
    /// Tohle pouze otáčí modelem ve směru pohybu hráče, abychom vytvořili iluzi o tom,
    /// že se hráč ve skutečnosti pohybuje a není to jen fyzický objekt ve tvaru kapsle
    /// co se nějakou náhodou pohybuje po herní scéně.
    /// </summary>
    public class BodyModel : MonoBehaviour
    {
        
        [Tooltip("Animator modelu.")]
        public Animator anim;
        
        [Tooltip("Dosazení hráčova Controlleru.")]
        public CharacterController characterController;
        
        [Tooltip("Dosazení hráčova těla. Na scéné jsou jen dva, to zvládneš.")]
        public Body playerBody;

        //Směr
        private Vector3 direction;
        public float rbMagnitude;
        private float animatorBlendValue;

        private void Update()
        {
            if (rbMagnitude > 0)
                animatorBlendValue = Mathf.Lerp(animatorBlendValue, rbMagnitude, 8 * Time.deltaTime);
            else
                animatorBlendValue = Mathf.Lerp(animatorBlendValue, 0, 8 * Time.deltaTime);
            
            //Hráč se nemůže hýbat = nemůže chodit
            if (!playerBody.GetCanMove())
            {
                //Vypneme animaci
                anim.SetFloat("Blend", animatorBlendValue);
                return;
            }
            
            //Zjišťujeme fyzickou rychlost hráče
            rbMagnitude = characterController.velocity.magnitude;
            
            //Nastavuje animaci
            anim.SetFloat("Blend", animatorBlendValue);

            //Směr chodu hráče
            direction = new Vector3(playerBody.moveDirection.x, 0, playerBody.moveDirection.z);

            //Pokud se hráč přestane hýbat, tak se rotace kvůli nedostatku magnitudu
            //vyresetuje. Tohle tomu předejde.

            if (rbMagnitude >= 0.3f)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 10 * Time.deltaTime);
            }
        }
    }
}
