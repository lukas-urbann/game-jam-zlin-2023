using UnityEngine;

namespace Traps
{
    public class TrapTrigger : MonoBehaviour
    {
        [Tooltip("Typ pasti, ať se ví které se mají invertovat")]
        public TrapType TrapType;
        
        private void OnTriggerEnter(Collider other)
        {
            //Hráč = invert pastí
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                TrapControl.Instance.lastTrapType = TrapType;
                TrapControl.Instance.trapSwitch.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
