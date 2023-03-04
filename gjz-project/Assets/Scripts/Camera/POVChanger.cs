using System;
using UnityEngine;

namespace Camera
{
    public class POVChanger : MonoBehaviour
    {
        public static POVChanger Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public UnityEngine.Camera camera1, camera2;

        private void Start()
        {
            if (camera1 == null || camera2 == null)
                ErrorReporter.ReportError(gameObject, "Nejsou přiřazené kamery.", this, "Musí se přiřadit do skriptu POVChanger.");
        }
    }
}
