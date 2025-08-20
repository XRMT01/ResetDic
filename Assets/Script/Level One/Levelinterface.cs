using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Levelinterface : MonoBehaviour
{
    public Button targetButton; // 要操作的按钮
    public GameObject hiddenObject; // 隐藏的对象
    public GameObject scoreObject; // 要显示的 Score 对象
    public Image buttonImage; // 按钮的 Image 组件
    public Sprite newSprite; // 要切换的新图片
    private Sprite originalSprite; // 原始图片
    private int clickCount = 0; // 记录按钮点击次数

    void Start()
    {
        // 为按钮添加点击事件监听器
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(OnButtonClick);
        }
        // 记录原始图片
        if (buttonImage != null)
        {
            originalSprite = buttonImage.sprite;
        }
    }

    // 按钮点击事件处理函数
    void OnButtonClick()
    {
        clickCount++;
        if (buttonImage != null && newSprite != null && originalSprite != null)
        {
            // 根据点击次数切换图片
            buttonImage.sprite = clickCount % 2 == 1 ? newSprite : originalSprite;
        }
        if (clickCount == 1)
        {
            if (buttonImage != null && newSprite != null)
            {
                // 第一次点击切换按钮图片
                buttonImage.sprite = newSprite;
            }
            if (hiddenObject != null)
            {
                // 第一次点击显示隐藏的对象
                scoreObject.SetActive(true);
                Setatssrue.Instance.Stars();
                Setatssrue.Instance.Kaishi();
            }
        }
        else if (clickCount == 2)
        {
            if (hiddenObject != null)
            {
                // 第二次点击隐藏对象
                scoreObject.SetActive(false);
            }
            clickCount = 0; // 重置点击次数
        }
    }
}