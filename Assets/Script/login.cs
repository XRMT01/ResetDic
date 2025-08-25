using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Text;

public class login : MonoBehaviour
{

    #region
    [Header("用户信息")]
    public GameObject UserPage;
    public TMP_Text UserNameText;
    public TMP_Text ScoreText;
    public Button ExitBtn;
    #endregion
    #region 登陆
    [Header("登陆注册部分")]
    public GameObject LoginPage;
    public TMP_InputField TMP_UserName;
    public TMP_InputField TMP_Password;
    public Button RegisterButton;
    public Button LoginButton;
    private const string RegisterUrl = "https://dic.free.xrmt.cn/api/auth/register";
    private const string LoginUrl = "https://dic.free.xrmt.cn/api/auth/login";
    private AuthResponse response;
    #endregion
    private void Start()
    {
        DisableBothButtons();
        RegisterButton.onClick.AddListener(async () =>
        {
            await Register(TMP_UserName.text, TMP_Password.text);
        });
        LoginButton.onClick.AddListener(async () =>
        {
            await Login(TMP_UserName.text, TMP_Password.text);
        });
        ExitBtn.onClick.AddListener(() =>
        {
            response = new AuthResponse();
            UserPage.SetActive(false);
            LoginPage.SetActive(false);
        });
    }

    [System.Serializable]
    public class AuthRequest
    {
        public string username;
        public string password;
        public string platform = "web"; // 可选参数
    }

    [System.Serializable]
    public class AuthResponse
    {
        public string token;
        public string message;
        public UserInfo user;
    }
    [System.Serializable]
    public class UserInfo
    {
        public int id;
        public string uid;
        public string username;
        public string platform;
        public int score;
    }

    // 注册方法
    public async Task Register(string username, string password)
    {
        var request = new AuthRequest
        {
            username = username,
            password = password
        };

        string json = JsonUtility.ToJson(request);// 将对象转换为JSON字符串
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);// 将字符串转换为字节数组

        // 发送POST请求
        using (UnityWebRequest webRequest = new UnityWebRequest(RegisterUrl, "POST"))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            UnityWebRequestAsyncOperation asyncOp = webRequest.SendWebRequest();

            while (!asyncOp.isDone)
            {
                await Task.Yield(); // 等待异步完成
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("注册失败: " + webRequest.error);
                Debug.LogError("响应内容: " + webRequest.downloadHandler.text);
                return;
            }

            response = JsonUtility.FromJson<AuthResponse>(webRequest.downloadHandler.text);
            Debug.Log("注册成功 - Token: " + response.token + ", Message: " + response.message);
            // 注册成功后，切换到用户页面
            UserPage.SetActive(true);
            LoginPage.SetActive(false);
            SetLoginInfo(response);
            EnableBothButtons();
        }
    }

    // 登录方法
    public async Task Login(string username, string password)
    {
        var request = new AuthRequest
        {
            username = username,
            password = password
        };

        string json = JsonUtility.ToJson(request);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest webRequest = new UnityWebRequest(LoginUrl, "POST"))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            UnityWebRequestAsyncOperation asyncOp = webRequest.SendWebRequest();

            while (!asyncOp.isDone)
            {
                await Task.Yield(); // 等待异步完成
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("登录失败: " + webRequest.error);
                Debug.LogError("响应内容: " + webRequest.downloadHandler.text);
                return;
            }

            response = JsonUtility.FromJson<AuthResponse>(webRequest.downloadHandler.text);
            Debug.Log("登录成功 - Token: " + response.token + ", Message: " + response.message);
            EnableBothButtons();
            // 登录成功界面切换
            UserPage.SetActive(true);
            LoginPage.SetActive(false);
            SetLoginInfo(response);
        }
    }

    // 设置登录信息
    public void SetLoginInfo(AuthResponse request)
    {

        UserNameText.text = $"玩家:{request.user.username}";
        ScoreText.text = "登录成功"/*$"Score:{request.user.score.ToString()}"*/;
    }
    
    public Button button1;
    public Button button2;


    public void DisableBothButtons()
    {
        if (button1 != null)
            button1.interactable = false;

        if (button2 != null)
            button2.interactable = false;
    }

    public void EnableBothButtons()
    {
        if (button1 != null)
            button1.interactable = true;

        if (button2 != null)
            button2.interactable = true;
    }
}

