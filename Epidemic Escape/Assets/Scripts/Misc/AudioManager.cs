using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudioSource;
    
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void PlayPlayerSound (AudioClip clip)
    {
        Playsound(playerAudioSource, clip);
    }

    public void Playsound (AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
