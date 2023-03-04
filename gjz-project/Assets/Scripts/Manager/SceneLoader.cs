using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    /// <summary>
    /// Načítá scény s animací.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        public Animator foregroundAnim;
        
        //Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void LoadSceneWithAnimation(string name)
        {
            StartCoroutine(AnimationLoad(name));
        }
        
        private IEnumerator AnimationLoad(string name)
        {
            foregroundAnim.Play("ForegroundMenuLeave");
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 1;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }
    }
}
