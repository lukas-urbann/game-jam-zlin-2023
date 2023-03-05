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
            if (other.CompareTag("Player"))
            {
                TrapControl.Instance.lastTrapType = TrapType;
                TrapControl.Instance.trapSwitch.Invoke();
            }
        }
    }
}
