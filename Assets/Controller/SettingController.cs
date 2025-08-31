
using System;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    private SettingViews m_views;
    public SettingViews SettingViews { get { return m_views; } }
    private static SettingController m_Instances;
    public static SettingController Instance 
    {
        get 
        {
            return m_Instances;
        }
    }
    public static void ShowMe() 
    {
        if (m_Instances == null) 
        {
            m_Instances = Instantiate(Resources.Load<SettingController>("Prefabs/Panel/SettingPanel"));
            m_Instances.transform.SetParent(GameObject.Find("Canvas").transform,false);
        }
        m_Instances.gameObject.SetActive(true);
    }
    public static void HideMe() {
        if (m_Instances != null) {
            m_Instances.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        m_views = this.GetComponent<SettingViews>();

        m_views.MusicVolume.onValueChanged.AddListener(OnMusicVolume);
        m_views.SoundVolume.onValueChanged.AddListener(OnSoundVolume);
        
        m_views.UpdateInfo();
        // 点击遮罩关闭
        m_views.Mask.onClick.AddListener(() =>
        {
            HideMe();
            GameManagers.Instance.SettingModel.SaveSetting();
            MusicController.Instance.PlaySound(null);
        });

        m_views.ToggleMusicOn.onValueChanged.AddListener(ToggleMusicOn);
        m_views.ToggleMusicOff.onValueChanged.AddListener(ToggleMusicOff);
        m_views.ToggleSoundOn.onValueChanged.AddListener(ToggleSoundOn);
        m_views.ToggleSoundOff.onValueChanged.AddListener(ToggleSoundOff);
    }

    

    private void OnDestroy()
    {
        m_views.MusicVolume.onValueChanged.RemoveListener(OnMusicVolume);
        m_views.SoundVolume.onValueChanged.RemoveListener(OnSoundVolume);
        m_views.ToggleMusicOn.onValueChanged.RemoveListener(ToggleMusicOn);
        m_views.ToggleMusicOff.onValueChanged.RemoveListener(ToggleMusicOff);
        m_views.ToggleSoundOn.onValueChanged.RemoveListener(ToggleSoundOn);
        m_views.ToggleSoundOff.onValueChanged.RemoveListener(ToggleSoundOff);
        m_views.Mask.onClick.RemoveAllListeners();
    }

    private void OnMusicVolume(float arg0)
    {

        GameManagers.Instance.SettingModel.MusicBackgroundVolume = arg0;
        EventCenter.TriggerEvent("OnMusicVolume");
    }

    private void OnSoundVolume(float arg0)
    {
        GameManagers.Instance.SettingModel.MusicSoundVolume = arg0;
        EventCenter.TriggerEvent("OnSoundVolume");
    }


    private void ToggleSoundOff(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
        GameManagers.Instance.SettingModel.IsSoundState = false;
        MusicController.Instance.PlaySound(false);
    }

    private void ToggleSoundOn(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
        GameManagers.Instance.SettingModel.IsSoundState = true;
        MusicController.Instance.PlaySound(true);
    }

    private void ToggleMusicOff(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
        GameManagers.Instance.SettingModel.IsMusicState = false;
        MusicController.Instance.PlayMusic(false);
    }

    private void ToggleMusicOn(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
        GameManagers.Instance.SettingModel.IsMusicState = true;
        MusicController.Instance.PlayMusic(true);
    }
}
