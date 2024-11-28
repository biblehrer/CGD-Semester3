using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip clip;
    public float volume;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(gameObject, clip.length +0.1f);
    }

    public void SetValues(float volume, AudioClip clip)
    {
        this.volume = volume;
        this.clip = clip;   
        audioSource.Play();
    }

    public void Update()
    {
        
    }

}
