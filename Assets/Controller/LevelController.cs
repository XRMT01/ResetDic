using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static LevelController m_instance;
    public static LevelController Instance 
    {
        get
        {
            return m_instance;
        }
    }
    private LevelViews m_views;
    public LevelViews Views => m_views;

    public static void ShowMe()
    {
        if (m_instance == null)
        {
            // 实例化面板
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Panel/LevelPanel"));
            // 将面板挂载到当前场景
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            m_instance = obj.GetComponent<LevelController>();
        }
        m_instance.gameObject.SetActive(true);
    }
    public static void HideMe()
    {
        if (m_instance != null)
        {
            m_instance.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        m_views = this.GetComponent<LevelViews>();

        m_views.Btn_Setting.onClick.AddListener(ClikeSettinBtn);
        m_views.Btn_Start.onValueChanged.AddListener(ClikeStartBtn);
        m_views.Btn_Store.onValueChanged.AddListener(ClikeStoreBtn);
        m_views.Btn_Rank.onValueChanged.AddListener(ClikeRankBtn);

        m_views.UpdateInfo();
    }

    private void ClikeRankBtn(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
    }

    private void ClikeStoreBtn(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
    }

    private void ClikeStartBtn(bool arg0)
    {
        MusicController.Instance.PlaySound(null);
    }

    private void ClikeSettinBtn()
    {
        MusicController.Instance.PlaySound(null);
        SettingController.ShowMe();
    }
}
