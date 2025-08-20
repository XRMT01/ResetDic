using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accomplishment : MonoBehaviour
{
    public Achievement One;
    public Achievement Two;
    public Achievement C;
    public Achievement Q;
    public Achievement K;
    public Achievement B;
    public Transform achPanel;
    public Text achNameText;
    public Text achDescriptionText;
    public Image AchImage;
    int videoAmount;
    int videoAmountT;

    private void Start()
    {
        FindObjectOfType<UImanager>().First += Upl;
        FindObjectOfType<UImanager>().Pige += Upln;
        FindObjectOfType<UImanager>().Chu += Ch;
        FindObjectOfType<UImanager>().Qi += Qt;
        FindObjectOfType<UImanager>().Bu += Bk;
        FindObjectOfType<UImanager>().Ke += Keh;
    }
    void Ch()
    {
        if (C.DaChen)
        { return; }
            PopNewAchievement(C);
    }
    void Qt()
    {
        if (Q.DaChen)
        { return; }
        PopNewAchievement(Q);
    }
    void Bk()
    {
        if (B.DaChen)
        { return; }
        PopNewAchievement(B);
    }
    void Keh()
    {
        if (K.DaChen)
        { return; }
        PopNewAchievement(K);
    }
    void Upl()
    {
        if (One == null)
        {
            Debug.LogError("Achievement 'One' is not set!");
            return;
        }
        if (One.DaChen)
            return;
        videoAmount += 5;
        if (videoAmount >= 50)
            PopNewAchievement(One);
    }

    void Upln()
    {
        if (Two == null)
        {
            Debug.LogError("Achievement 'One' is not set!");
            return;
        }
        if (Two.DaChen)
            return;
        videoAmountT += 5;
        if (videoAmountT >= 30)
            PopNewAchievement(Two);
    }
    void PopNewAchievement(Achievement ach) 
    {
       // int run = PlayerPrefs.GetInt(ach.achName, 1);
       // if (run == 0)
       // {
            if (achNameText == null || achDescriptionText == null)
            {
                Debug.LogError("Achievement UI Texts are not set!");
                return;
            }
            achNameText.text = ach.achName;
            achDescriptionText.text = ach.achDescription;
            AchImage.sprite = ach.Aimage;
            ach.DaChen = true;
            PlayerPrefs.SetInt(ach.achName, 1);
         //   PlayerPrefs.Save();
            //Recording(ach.achName);
            StartCoroutine(PopThePanel());
       // }
       // else
        //{
          //  return;
        //}
    }
    IEnumerator PopThePanel() 
    {
        float percent = 0;
        float amount = 3f;
        while (percent < 1)
        {
            //Debug.Log(622223);
            percent += Time.deltaTime / 1f;
            achPanel.position += Vector3.down * amount * Time.deltaTime / 1f;

            yield return null;
        }
        yield return new WaitForSeconds(1);
        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            achPanel.position += Vector3.up * amount * Time.deltaTime / 1f;

            yield return null;
        }
    }

    public void Recording(string Name) 
    {
        if (Name == "One")
        {
            PlayerPrefs.SetInt("One", 1);
            PlayerPrefs.Save();
        }
        if (Name == "Two")
        {
            PlayerPrefs.SetInt("Two", 1);
            PlayerPrefs.Save();
        }
    }
}
[System.Serializable]

public class Achievement
{
    public string achName; 
    public string achDescription; 
    public bool DaChen; 
    public Sprite Aimage;
}
