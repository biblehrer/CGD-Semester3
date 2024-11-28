using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager; 

    public AudioSource[] sources;


    // Start is called before the first frame update
    void Start()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    public void PlaySound(int soundID)
    {
        sources[soundID].Play();
        sources[soundID].volume = 0;
    }
}
