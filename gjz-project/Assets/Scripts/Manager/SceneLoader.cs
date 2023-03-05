using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    /// <summary>
    /// Načítá scény s přechodnou animací.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        public Animator foregroundAnim;
        
        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            if(foregroundAnim == null)
                ErrorReporter.ReportError(gameObject, "Chybí dosazený Animator.", this, "SceneLoader potřebuje dosadit foreground animator.");
        }

        public void LoadSceneWithAnimation(string name)
        {
            StartCoroutine(AnimationLoad(name));
        }
        
        private IEnumerator AnimationLoad(string name)
        {
            //Přehraje animaci
            foregroundAnim.Play("ForegroundMenuLeave");
            yield return new WaitForSecondsRealtime(1f);
            //Načte scénu
            Time.timeScale = 1; //Tohle je smrtelně důležité
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }
    }
}
