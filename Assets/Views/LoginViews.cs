using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginViews : BaseViews
{
    [Header("ÊäÈëÄÚÈİ")]
    public TMP_InputField Input_Name;
    public TMP_InputField Input_Password;
    [Header("µÇÂ¼°´Å¥")]
    public Button Btn_Login;
    [Header("×¢²á°´Å¥")]
    public Button Btn_Register;

    protected override void RegisterEvents()
    {

    }

    protected override void UnregisterEvents()
    {

    }

}
