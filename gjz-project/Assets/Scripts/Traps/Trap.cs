using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class Trap : MonoBehaviour
    {
        public string enablepast, disablepast;
        public TrapType TrapType;
        public Animator anim;
        public float killTime = 1;
        public bool isEnabled = false;

        public bool canKill = false;
        public Collider collider;

        private void Start()
        {
            TrapControl.Instance.trapSwitch += CheckTrapType;
            anim = GetComponent<Animator>();
            collider = GetComponent<Collider>();
        }

        protected void DisableTrap()
        {
            isEnabled = false;
            anim.Play(disablepast);
        }

        protected void EnableTrap()
        {
            isEnabled = true;
            anim.Play(enablepast);
        }

        private IEnumerator StartKillTime()
        {
            canKill = true;
            collider.isTrigger = true;
            yield return new WaitForSeconds(killTime);
            canKill = false;
            collider.isTrigger = false;
        }

        protected void CheckTrapType()
        {
            if(!isEnabled)
                StartCoroutine(StartKillTime());
            
            if (TrapType == TrapControl.Instance.lastTrapType)
                EnableTrap();
            else
                DisableTrap();
        }
    }
}
