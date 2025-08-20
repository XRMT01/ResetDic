using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    public AudioSource[] audioSources; // 拖入多个AudioSource组件  
    private bool isSoundOn = true; // 音效默认开启  

    // 切换音效状态的方法  
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource != null) // 确保AudioSource不是null  
            {
                if (isSoundOn)
                {
                    // 如果音效是循环的，并且已经播放，则不需要再次播放  
                    // 但如果音效是非循环的，或者你想要确保它重新开始播放  
                    // 你可以在这里调用audioSource.Play()  
                    if (!audioSource.isPlaying && !audioSource.loop)
                    {
                        audioSource.Play();
                    }
                    // 如果之前降低了音量，可以在这里恢复  
                    // audioSource.volume = 1.0f;  
                }
                else
                {
                    // 停止音效  
                    audioSource.Stop();
                    // 如果需要完全静音，可以在这里设置音量  
                    // audioSource.volume = 0.0f;  
                    // 但通常停止音效就足够了，除非你有特殊需求  
                }
            }
        }
    }
}
