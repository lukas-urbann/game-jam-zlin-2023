using UnityEngine;

namespace Traps
{
    //Typy pastí
    public enum TrapType
    {
        Vines,
        Tree,
        Mountain
    }
    
    /// <summary>
    /// Něco jako manager, ale pro pasti.
    /// Ve scéně je jen jednou a má specifické použití, volají na něho pasti.
    /// </summary>
    public class TrapControl : MonoBehaviour
    {
        //Singleton
        public static TrapControl Instance;

        //Delegát, abychom mohli aktualizovat všechny pasti zároveň
        //a nemuseli všecky objekty narvat do listu a dělat to manuálně.
        public delegate void TrapSwitchAlert();
        public TrapSwitchAlert trapSwitch;
        
        //Poslední aktivovaná past
        public TrapType lastTrapType;

        private void Awake()
        {
            Instance = this;
        }
    }
}
