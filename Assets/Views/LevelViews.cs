using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelViews : BaseViews
{
    [Header("功能按钮")]
    public Button Btn_Setting;
    public Toggle Btn_Start;
    public Toggle Btn_Store;
    public Toggle Btn_Rank;
    [Header("个人数据")]
    public TMP_Text Text_Score;
    protected override void RegisterEvents()
    {

    }

    protected override void UnregisterEvents()
    {

    }

    public void UpdateInfo()
    {
        Text_Score.text = PlayerPrefs.GetInt("score", 0).ToString();
    }
}
