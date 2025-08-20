using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; // 引入 UI 命名空间

public class Scenejump : MonoBehaviour
{
    public Button jumpButton;
    public GameObject ScrePing;

    // Start is called before the first frame update
    void Start()
    {
        if (jumpButton != null)
        {
            // 为按钮添加点击事件监听器
            jumpButton.onClick.AddListener(JumpToNextScene);
        }
    }

    // 跳转到下一个场景的方法
    void JumpToNextScene()
    {

        ScrePing.SetActive(true);
        Setatssrue.Instance.Stars();
        Setatssrue.Instance.Kaishi();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
