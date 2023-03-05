using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class TrapTrigger : MonoBehaviour
    {
        public TrapType TrapType;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                TrapControl.Instance.lastTrapType = TrapType;
                TrapControl.Instance.trapSwitch.Invoke();
            }
        }

        
    }
}
