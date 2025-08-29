using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public List<AudioClip> BgList = new List<AudioClip>();
    public AudioSource audioSource;

    [Header("默认点击音效")]
    public AudioClip clickSound;
    private int index;

    public static MusicController Instance;

    private List<AudioSource> SoundAudioSoures = new List<AudioSource>();
    private bool isPlaySound = true;
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EventCenter.AddListener("OnMusicVolume", OnMusicValume);
        EventCenter.AddListener("OnSoundVolume", OnSoundValume);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener("OnMusicVolume", OnMusicValume);
        EventCenter.RemoveListener("OnSoundVolume", OnSoundValume);
    }
    private void OnSoundValume()
    {
        foreach (var item in SoundAudioSoures)
        {
            item.volume = GameMangers.Instance.SettingModel.MusicSoundVolume;
        }
    }

    private void OnMusicValume()
    {
        audioSource.volume = GameMangers.Instance.SettingModel.MusicBackgroundVolume;
    }


    // 播放音乐
    public void PlayMusic(bool isPlay = true)
    {
        audioSource.clip = BgList[index];
        if (isPlay)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
    public void PlayMusic(int index)
    {
        _PlayMusic(index);
    }

    private void _PlayMusic(int index)
    {
        this.index = index;
        audioSource.clip = BgList[index];
        audioSource.Play();
    }

    // 停止音乐
    public void StopMusic()
    {
        audioSource.Pause();
    }

    private void FixedUpdate()
    {
        if (audioSource.clip == null || !audioSource.isPlaying) return;
        // 获取当前音乐播放时长
        float time = audioSource.time;
        if (time >= audioSource.clip.length)
        {
            // 播放完毕
            if (index < BgList.Count - 1)
            {
                // 播放下一首
                index++;
                _PlayMusic(index);
                audioSource.time = 0;
            }
            else
            {
                // 播放完毕
                _PlayMusic(0);
                audioSource.time = 0;
                index = 0;
            }
        }
    }

    // 播放音效
    public void PlaySound(AudioClip clip = null)
    {
        if (isPlaySound) {
            _PlaySound(clip);
        }
    }
    public void PlaySound(bool isPlay = true) 
    {
        if (isPlay)
        {
            isPlaySound = true;
            _PlaySound(clickSound);
        }
        else 
        {
            isPlaySound = false;
        }
    }
    
    private void _PlaySound(AudioClip clip)
    {
        // 先从缓存中获取没有播放的播放器来播放音效
        AudioSource source = SoundAudioSoures.Find(x => !x.isPlaying);
        // 如果没有则创建一个
        if (source == null)
        {
            source = new GameObject("Sound").AddComponent<AudioSource>();
            source.playOnAwake = false;
            SoundAudioSoures.Add(source);
        }
        source.clip = clip == null ? clickSound : clip;
        source.Play();
    }
}
