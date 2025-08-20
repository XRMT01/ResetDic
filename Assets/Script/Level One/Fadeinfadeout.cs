using UnityEngine;
using UnityEngine.UI;

public class Fadeinfadeout : MonoBehaviour
{
    public GameObject targetObject;
    public Button showButton;
    public Button hideButton;
    public Image imageA;
    public Image imageB;
    public Button topAButton;
    public Button topBButton;
    private bool isTopA = true; // 初始假设 A 在顶部

    void Start()
    {
        targetObject.SetActive(false);
        showButton.onClick.AddListener(ShowObject);
        hideButton.onClick.AddListener(HideObject);

        // 绑定按钮点击事件（关键修改）
        if (topAButton != null) topAButton.onClick.AddListener(SwitchToA);
        if (topBButton != null) topBButton.onClick.AddListener(SwitchToB);

        if (imageA != null) imageA.gameObject.SetActive(true);
        if (imageB != null) imageB.gameObject.SetActive(true);
    }

    private void ShowObject() => targetObject.SetActive(true);
    private void HideObject() => targetObject.SetActive(false);

    // 新增：切换到 A 顶部的方法
    private void SwitchToA()
    {
        if (!isTopA) // 只有当前不是 A 顶部时才切换
        {
            SetImageOrder(imageA, imageB);
            isTopA = true;
        }
    }

    // 新增：切换到 B 顶部的方法
    private void SwitchToB()
    {
        if (isTopA) // 只有当前是 A 顶部时才切换
        {
            SetImageOrder(imageB, imageA);
            isTopA = false;
        }
    }

    // 提取通用层级设置逻辑
    private void SetImageOrder(Image topImage, Image bottomImage)
    {
        if (topImage == null || bottomImage == null || topImage.transform.parent == null) return;

        Transform parent = topImage.transform.parent;
        int totalChildren = parent.childCount;
        topImage.transform.SetSiblingIndex(totalChildren - 4);  // 设为顶部
        bottomImage.transform.SetSiblingIndex(totalChildren - 5);// 设为次顶部
    }

    private void CheckBButtonClick()
    {
        Debug.Log("检测到 Top B Button 被点击");
    }
}