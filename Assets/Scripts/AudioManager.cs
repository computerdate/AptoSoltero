using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioClip putDownSound;
    public AudioClip wrongStepSound;
    public AudioClip applauseSound;
    private AudioSource audioSource;
    public static AudioManager Instance;

    void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }       
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void playPickUpSound() {
        audioSource.PlayOneShot(pickupSound, 1.0f);
    }

    public void playPutDownSound() {
        audioSource.PlayOneShot(putDownSound, 1.0f);
    }

    public void playErrorSound() {
        audioSource.PlayOneShot(wrongStepSound, 1.0f);
    }

    public void playApplauseSound() {
        audioSource.PlayOneShot(applauseSound, 1.0f);
    }

}
