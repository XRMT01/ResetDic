using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceDai : MonoBehaviour
{
    public AudioSource audioSource;
    public static SourceDai Instance;
    public void PlaySound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
       
    }

    void Start()
    {
        Instance = this;
    }
}
