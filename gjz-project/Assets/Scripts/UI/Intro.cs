
using UnityEngine;

namespace Intro
{
    /// <summary>
    /// Spouští úvodní papírek o ovládání při prvním spuštění hry
    /// </summary>
    public class Intro : MonoBehaviour
    {
        private int intro = 0;
        private Animator animator;
        
        private void Start()
        {
            animator = GetComponent<Animator>();
            animator.enabled = false;
            
            intro = PlayerPrefs.GetInt("playIntro", 0);

            if (intro != 0)
                return;
                
            animator.enabled = true;
            PlayerPrefs.SetInt("playIntro", 1);
            PlayerPrefs.Save();
        }
    }
}

