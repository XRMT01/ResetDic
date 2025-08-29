using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangers : MonoBehaviour
{
    public static GameMangers Instance;

    public SettingModel SettingModel = new SettingModel();
    void Start()
    {
        // 单例
        Instance = this;
        // 显示主界面
        MainController.ShowMe();

        // 加载设置
        SettingModel.LoadSetting();
    }

    void Update()
    {
        
    }
}
