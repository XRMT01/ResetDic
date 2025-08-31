using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class RequestController : MonoBehaviour
{
    // 请求地址
    public string RequestUrl = "https://dic.free.xrmt.cn/api/";
    private static RequestController m_instance = null;
    public static RequestController Instance
    {
        get
        {
            if (m_instance == null)
            {
                GameObject obj = new GameObject("RequestController");
                m_instance = obj.AddComponent<RequestController>();
                DontDestroyOnLoad(obj);
            }
            return m_instance;
        }
    }

    public void GetRequest(string url, string token, Action<string> callback)
    {
        StartCoroutine(Get(url, token, callback));
    }
    IEnumerator Get(string url, string token, Action<string> callback)
    {
        // 创建请求
        Debug.Log("Get请求：" + RequestUrl + url);
        UnityWebRequest webRequest = UnityWebRequest.Get(RequestUrl+url);
        // 设置请求头
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Accept", "application/json");
        webRequest.SetRequestHeader("Authorization", "Bearer " + token);
        // 发送请求并等待响应
        yield return webRequest.SendWebRequest();
        // 检查请求是否成功
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("请求失败：" + webRequest.error);
            Debug.LogError("响应内容: " + webRequest.downloadHandler.text);
        }
        else
        {
            // 处理响应数据
            string response = webRequest.downloadHandler.text;
            callback(response);
        }

    }

    public void PostRequest(string url, string json, Action<string> callback)
    {
        StartCoroutine(Post(url, json, callback));
    }
    IEnumerator Post(string url, string json, Action<string> callback)
    { 
        Debug.Log("Post请求：" + RequestUrl + url);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        using (UnityWebRequest webRequest = new UnityWebRequest(RequestUrl+url, "POST"))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            UnityWebRequestAsyncOperation asyncOp = webRequest.SendWebRequest();
            while (!asyncOp.isDone)
            {
                yield return null;
            }
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("请求失败：" + webRequest.error);
                Debug.LogError("响应内容: " + webRequest.downloadHandler.text);
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                callback(response);
            }
            yield break;
        }
    }
}
