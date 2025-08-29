using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private MainViews m_views;

    private static MainController m_instance = null;
    public static MainController Instance
    {
        get
        {
            return m_instance;
        }
    }

    public static void ShowMe() 
    {
        if (m_instance == null) 
        {
            // 实例化面板
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Panel/MainPanel"));
            // 将面板挂载到当前场景
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);

            m_instance = obj.GetComponent<MainController>();
        }
        m_instance.gameObject.SetActive(true);
    }
    public static void HideMe()
    {
        if (m_instance != null) {
            m_instance.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        m_views = this.GetComponent<MainViews>();

        m_views.btn_Start.onClick.AddListener(ClikeLoadGameBtn);
        m_views.btn_Setting.onClick.AddListener(ClikeSettingBtn);
    }
    private void OnDestroy()
    {
        m_views.btn_Start.onClick.RemoveListener(ClikeLoadGameBtn);
        m_views.btn_Setting.onClick.RemoveListener(ClikeSettingBtn);
    }

    private void ClikeLoadGameBtn()
    {
        MusicController.Instance.PlaySound(null);
        Debug.Log("开始加载游戏...");
    }
    private void ClikeSettingBtn()
    {
        MusicController.Instance.PlaySound(null);
        SettingController.ShowMe();
        Debug.Log("打开设置界面...");
    }
}
