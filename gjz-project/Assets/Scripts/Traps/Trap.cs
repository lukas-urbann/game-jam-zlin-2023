using System.Collections;
using UnityEngine;

namespace Traps
{
    /// <summary>
    /// Každá past musí mít tento skript.
    /// Tím myšleno objekt, který funguje jako past, ne její trigger.
    /// </summary>
    public class Trap : MonoBehaviour
    {
        [Tooltip("Fyzické názvy animací v animátoru objektu, které se přehrají")]
        public string enableTrapAnimationName, disableTrapAnimationName;
        
        [Tooltip("Typ pasti. Kontroluje které se zapnou nebo vypnou jako další.")]
        public TrapType TrapType;
        
        [Tooltip("Animátor pasti")]
        private Animator anim;
        
        [Tooltip("Čas, který udává jak dlouho po aktivaci pasti je past smrtelná")]
        public float killTime = 1;

        [Tooltip("Ukazuje zda je past zaplá")] public bool isEnabled;

        [Tooltip("Ukazuje zda past může zabít hráče při doteku")] public bool canKill;
        
        [Tooltip("Collider, který se přepíná mezi triggerem a normálním.")]
        public Collider objCollider;

        private void Start()
        {
            //Přidáme void do delegátu
            TrapControl.Instance.trapSwitch += CheckTrapType;
            
            //Tohle se dosadí samo z objektu
            anim = GetComponent<Animator>();
            
            if(objCollider == null)
                objCollider = GetComponent<Collider>();
        }

        private void DisableTrap()
        {
            isEnabled = false;
            anim.Play(enableTrapAnimationName);
            objCollider.enabled = true;
        }

        private void EnableTrap()
        {
            isEnabled = true;
            anim.Play(disableTrapAnimationName);
            objCollider.enabled = false;
        }

        /// <summary>
        /// Jednoduchý killswitch
        /// </summary>
        /// <returns>Nic</returns>
        private IEnumerator StartKillTime()
        {
            canKill = true;
            objCollider.isTrigger = true;
            
            yield return new WaitForSeconds(killTime);
            
            canKill = false;
            objCollider.isTrigger = false;
        }

        /// <summary>
        /// Kontroluje typ pasti a připraví další pasti dle potřeby.
        /// </summary>
        private void CheckTrapType()
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
