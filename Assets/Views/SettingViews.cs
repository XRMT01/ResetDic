using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingViews : BaseViews
{
    public Scrollbar MusicVolume;
    public Scrollbar SoundVolume;
    public ToggleGroup MusicState;
    public Toggle ToggleMusicOn;
    public Toggle ToggleMusicOff;
    public ToggleGroup SoundState;
    public Toggle ToggleSoundOn;
    public Toggle ToggleSoundOff;

    public Button Mask;

    protected override void RegisterEvents()
    {
        // TODO: 注册音乐与音效进度条事件
        EventCenter.AddListener("OnMusicVolume", MusicVolumeChange);
        EventCenter.AddListener("OnSoundVolume", SoundVolumeChange);
        EventCenter.AddListener("OnMusicState", MusicStateChange);
        EventCenter.AddListener("OnSoundState", SoundStateChange);
    }

    

    protected override void UnregisterEvents()
    {
        // TODO: 卸载音乐与音效进度条事件
        EventCenter.RemoveListener("OnMusicVolume", MusicVolumeChange);
        EventCenter.RemoveListener("OnSoundVolume", SoundVolumeChange);
        EventCenter.RemoveListener("OnMusicState", MusicStateChange);
        EventCenter.RemoveListener("OnSoundState", SoundStateChange);
    }

    public void UpdateInfo() 
    {
        MusicVolumeChange();
        SoundVolumeChange();
        MusicStateChange();
        SoundStateChange();
    }

    private void MusicVolumeChange()
    {
        MusicVolume.value = GameManagers.Instance.SettingModel.MusicBackgroundVolume;
    }

    private void SoundVolumeChange()
    {
        SoundVolume.value = GameManagers.Instance.SettingModel.MusicSoundVolume;
    }

    private void SoundStateChange()
    {
        if (GameManagers.Instance.SettingModel.IsSoundState)
        {
            ToggleSoundOn.isOn = true;
        }
        else
        {
            ToggleSoundOff.isOn = true;
        }
    }

    private void MusicStateChange()
    {
        if (GameManagers.Instance.SettingModel.IsMusicState) 
        {
            ToggleMusicOn.isOn = true;
        }else 
        {
            ToggleMusicOff.isOn = true;
        }
    }

}
