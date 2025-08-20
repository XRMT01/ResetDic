using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SourceZHi : MonoBehaviour
{
    public AudioSource audioSource;
    public static SourceZHi Instance;
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
