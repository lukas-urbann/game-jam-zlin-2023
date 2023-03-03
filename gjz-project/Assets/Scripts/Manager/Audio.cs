using System;
using UnityEngine;

namespace Manager
{
    public class Audio : MonoBehaviour
    {
        public static Audio Instance;
        public AudioClip buttonHover, buttonClick;
        public AudioSource audioSource;
        
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

        public void PlayButtonHover()
        {
            audioSource.PlayOneShot(buttonHover);
        }

        public void PlayButtonClick()
        {
            audioSource.PlayOneShot(buttonClick);
        }

        public void PlaySoundOneShot(AudioClip sound)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}
