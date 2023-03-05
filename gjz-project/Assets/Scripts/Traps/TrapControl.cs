using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Traps
{
    public enum TrapType
    {
        Vines,
        Tree,
        Mountain
    }
    
    public class TrapControl : MonoBehaviour
    {
        public static TrapControl Instance;

        public delegate void TrapSwitchAlert();

        public TrapSwitchAlert trapSwitch;

        public TrapType lastTrapType;

        private void Awake()
        {
            Instance = this;
        }
    }
}
