using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private MainViews m_views;
    public MainViews MainViews { get { return m_views; } }

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

        m_views.animator.SetTrigger("trigger");
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
        // 判断当前是否登陆
        // 读取本地存储cookie
        string Token = PlayerPrefs.GetString("token", null);
        Debug.Log(Token);
        if (string.IsNullOrEmpty(Token))
        {
            Debug.Log("请先登录...");
            LoginController.ShowMe();
        }
        else
        {
            // 验证是否已经过期
            RequestController.Instance.GetRequest("user/profile", Token, (response) =>
            {
                AuthResponse authResponse = JsonUtility.FromJson<AuthResponse>(response);
                Debug.Log(authResponse.user.uid);
                Debug.Log(PlayerPrefs.GetString("uid"));
                if (authResponse.user.uid != PlayerPrefs.GetString("uid"))
                {
                    Debug.Log("请重新登录...");
                    LoginController.ShowMe();
                }
                else 
                {
                    Debug.Log("欢迎回来，" + authResponse.user.username);
                    Debug.Log("当前分数：" + authResponse.user.score);
                    PlayerPrefs.SetInt("score", authResponse.user.score);
                    PlayerPrefs.Save();

                    m_views.animator.SetTrigger("trigger");
                    Debug.Log("开始加载游戏...");
                    LoadsManager.Instance.LoadScene("Level", () =>
                    {
                        MusicController.Instance.ChangeMusic();
                        m_views.animator.SetTrigger("trigger");
                    });
                    m_views.StatrLoads();
                }
            });


            
        }
        
    }

    public void ClikeEneterGame() 
    {
        m_views.animator.SetTrigger("trigger");
        Debug.Log("开始加载游戏...");
        LoadsManager.Instance.LoadScene("Level", () =>
        {
            MusicController.Instance.ChangeMusic();
            m_views.animator.SetTrigger("trigger");
        });
        m_views.StatrLoads();
    }
    private void ClikeSettingBtn()
    {
        MusicController.Instance.PlaySound(null);
        SettingController.ShowMe();
        Debug.Log("打开设置界面...");
    }
}
