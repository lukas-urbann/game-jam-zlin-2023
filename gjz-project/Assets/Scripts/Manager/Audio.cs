using UnityEngine;

namespace Manager
{
    /// <summary>
    /// Audio Singleton, přehrává zvuky, MĚL by být na každé scéně.
    /// Jakože, být tam nemusí ale vyhodí to chybu. The choice is yours mr. freeman
    /// </summary>
    public class Audio : MonoBehaviour
    {
        //Singleton
        public static Audio Instance;
        
        //Zvuky pro čudlíky, aby se nemusely doplňovat zvuky na každém tlačítku
        public AudioClip buttonHover, buttonClick;
        
        //Zdroj zvuku
        [SerializeField] private AudioSource audioSource;
        
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
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayButtonHover()
        {
            audioSource.PlayOneShot(buttonHover);
        }

        public void PlayButtonClick()
        {
            audioSource.PlayOneShot(buttonClick);
        }

        //Přehraje vlastní zvuk *pod master skupinou 'Effects'*
        public void PlaySoundOneShot(AudioClip sound)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}
