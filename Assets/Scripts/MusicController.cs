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

    private static MusicController instance;
    public static MusicController Instance 
    {
        get
        {
            if (instance == null)
            {
                MusicController obj = Instantiate(Resources.Load<MusicController>("Prefabs/Function/MusicBakcground"));
                DontDestroyOnLoad(obj);
                instance = obj.GetComponent<MusicController>();
            }
            return instance;
        }
    }

    private List<AudioSource> SoundAudioSoures = new List<AudioSource>();
    private bool isPlaySound = true;

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
            item.volume = GameManagers.Instance.SettingModel.MusicSoundVolume;
        }
    }

    private void OnMusicValume()
    {
        audioSource.volume = GameManagers.Instance.SettingModel.MusicBackgroundVolume;
    }
    // 切换下一首
    public void ChangeMusic(int index = -1)
    {
        // index 如果为-1 则播放下一首

        if (index == -1)
        {
            if (this.index < BgList.Count - 1)
            {
                this.index++;
            }
            else
            {
                this.index = 0;
            }
            _PlayMusic(this.index);
        }
        else
        {
            _PlayMusic(index);
        }
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
        audioSource.Stop(); // 强制停止当前播放
        audioSource.clip = BgList[index];
        audioSource.time = 0; // 重置播放时间为0
        audioSource.Play();   // 开始播放新音乐
    }

    // 停止音乐
    public void StopMusic()
    {
        audioSource.Pause();
    }

    private void Update()
    {
        if (audioSource.clip == null || !audioSource.isPlaying) return;

        float time = audioSource.time;
        if (time >= audioSource.clip.length - 0.1f) // 增加容错（0.1秒）
        {
            if (index < BgList.Count - 1)
            {
                index++;
                _PlayMusic(index);
            }
            else
            {
                index = 0;
                _PlayMusic(0);
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
    // 过程清除缓存

    public void CloseSound() 
    {
        SoundAudioSoures.Clear();
    }
}
