using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainViews : BaseViews
{
    public Button btn_Start;
    public Button btn_Setting;

    [Header("加载组件")]
    public Slider slider_Loading;
    public TMP_Text text_Loading;

    [Header("动画")]
    public Animator animator;
    private void Start()
    {
        slider_Loading.gameObject.SetActive(false);
        slider_Loading.value = 0;
        text_Loading.text = "0%";
    }

    public void StatrLoads() 
    {
        slider_Loading.gameObject.SetActive(true);
        btn_Start.gameObject.SetActive(false);
    }
    protected override void RegisterEvents()
    {

    }

    protected override void UnregisterEvents()
    {

    }

}
