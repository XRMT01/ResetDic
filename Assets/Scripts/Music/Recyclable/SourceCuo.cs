using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceCuo : MonoBehaviour
{
    public AudioSource audioSource;
    public static SourceCuo Instance;
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
