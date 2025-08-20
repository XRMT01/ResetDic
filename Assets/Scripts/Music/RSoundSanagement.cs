using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RSoundSanagement : MonoBehaviour
{
    public static RSoundSanagement Instance;
    public int Recycling;
    public GameObject RXlajidui;
    public GameObject RDlajidui;
    public GameObject FXlajidui;
    public GameObject FDlajidui;
    public int YesRecycling;
    public int YesFecycling;
  
    
  
    void Start()
    {

        Instance = this;
        FindObjectOfType<Reboot>().RebootL += Zero;
    }
   
    public void Zero() 
    {
        YesRecycling = 0;
        YesFecycling = 0;
}


    public void RecyclingSoundSanagement(int Recycling) //可回收音效
    {
        //Debug.Log(0111);
        if (Recycling == 0) 
        {
            SourceCuo.Instance.PlaySound(); 
        }
        if (Recycling == 1) 
        {
            YesRecycling += 1;
            SourceZHi.Instance.PlaySound(); 
        }
    }
    public void FecyclingSoundSanagement(int Recycling) //厨余收音效
    {
        if (Recycling == 0)
        {
            SourceCuo.Instance.PlaySound();
        }
        if (Recycling == 1)
        {
            YesFecycling += 1;
            SourceDai.Instance.PlaySound();
        }
    }
    void Update() 
    {
        if (YesRecycling >= 4) 
        {
         RXlajidui.SetActive(true);
        }
        else
        {
            RXlajidui.SetActive(false); 
        }
        if (YesRecycling >= 8)
        {
            RDlajidui.SetActive(true);
        }
        else
        {
            RDlajidui.SetActive(false);
        }
        if (YesFecycling >= 4)
        {
            FXlajidui.SetActive(true);
        }
        else
        {
            FXlajidui.SetActive(false);
        }
        if (YesFecycling >= 8)
        {
            FDlajidui.SetActive(true);
        }
        else
        {
            FDlajidui.SetActive(false);
        }
    }
}

public enum WasteBtnType 
{
    /// <summary>
    /// 左边按钮
    /// </summary>
    Left,
    /// <summary>
    /// 右边按钮
    /// </summary>
    Right,

}
