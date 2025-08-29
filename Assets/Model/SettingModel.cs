using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingModel
{
    public float MusicBackgroundVolume;
    public float MusicSoundVolume;
    public bool IsMusicState;
    public bool IsSoundState;
    // ≥ı ºªØ÷µ
    public void InitSetting()
    {
        MusicBackgroundVolume = 0.5f;
        MusicSoundVolume = 0.5f;
        IsMusicState = true;
        IsSoundState = true;
        SetConfig();
    }

    // ±£¥Ê≈‰÷√
    public void SaveSetting()
    {
        PlayerPrefs.SetFloat("MusicBackgroundVolume", MusicBackgroundVolume);
        PlayerPrefs.SetFloat("MusicSoundVolume", MusicSoundVolume);
        PlayerPrefs.SetInt("IsMusicState", IsMusicState ? 1 : 0);
        PlayerPrefs.SetInt("IsSoundState", IsSoundState ? 1 : 0);
        PlayerPrefs.Save();
    }
    // º”‘ÿ≈‰÷√
    public void LoadSetting()
    {
        MusicBackgroundVolume = PlayerPrefs.GetFloat("MusicBackgroundVolume", 1);
        MusicSoundVolume = PlayerPrefs.GetFloat("MusicSoundVolume", 1);
        IsMusicState = PlayerPrefs.GetInt("IsMusicState", 1) == 1;
        IsSoundState = PlayerPrefs.GetInt("IsSoundState", 1) == 1;
        SetConfig();
    }

    // …Ë÷√≈‰÷√
    public void SetConfig()
    {
        MusicController.Instance.audioSource.volume = MusicBackgroundVolume;
        MusicController.Instance.PlayMusic(IsMusicState);
        MusicController.Instance.PlaySound(IsSoundState);
    }
}
