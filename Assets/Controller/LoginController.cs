using System;
using Unity.VisualScripting;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    private LoginViews m_views;
    public LoginViews MainViews { get { return m_views; } }

    private static LoginController m_instance = null;
    public static LoginController Instance
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
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Panel/LoginPanel"));
            // 将面板挂载到当前场景
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            m_instance = obj.GetComponent<LoginController>();
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
        m_views = this.GetComponent<LoginViews>();
        m_views.Btn_Login.onClick.AddListener(ClikeLoginBtn);
        m_views.Btn_Register.onClick.AddListener(ClikeRegisterBtn);
    }

    private void ClikeRegisterBtn()
    {
        Debug.Log("注册");
    }

    private void ClikeLoginBtn()
    {
        Debug.Log("登录");
        if (m_views.Input_Name.text.Length > 0 && m_views.Input_Password.text.Length > 0 )
        {
            AuthRequest auth = new AuthRequest()
            {
                username = m_views.Input_Name.text,
                password = m_views.Input_Password.text
            };
            string json = JsonUtility.ToJson(auth);
            RequestController.Instance.PostRequest("auth/login", json ,(result) =>
            {
                Debug.Log(result);
                AuthResponse authResponse = JsonUtility.FromJson<AuthResponse>(result);
                if (authResponse.token != null)
                {
                    Debug.Log("登录成功");
                    PlayerPrefs.SetString("token", authResponse.token);
                    PlayerPrefs.SetString("username", authResponse.user.username);
                    PlayerPrefs.SetInt("score", authResponse.user.score);
                    PlayerPrefs.SetString("uid", authResponse.user.uid);
                    PlayerPrefs.Save();
                    Debug.Log("Token: " + authResponse.token);
                    Debug.Log("Username: " + authResponse.user.username);
                    Debug.Log("Score: " + authResponse.user.score);
                    Debug.Log("UID: " + authResponse.user.uid);
                    // 登录成功，隐藏登录面板
                    HideMe();
                    // 显示主菜单面板
                    MainController.Instance.ClikeEneterGame();
                }
                else
                {
                    Debug.Log("登录失败: " + authResponse.message);
                }
            });
        }
    }
}
