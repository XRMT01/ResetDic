using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;
using static UnityEngine.ParticleSystem;

public class UImanager : MonoBehaviour
{
    public Text correctText;
    public Text errorText;
    public Text missText;
    public static UImanager Instance;
    public int correctCount;
    public int errorCount;
    public int missCount;
    public int DanCiFScore;
    public Text ZcorrectText;
    public Text DanCiFScoreTXT;
    public bool Unrated;
    public string Thehighestrecord;
    public int Settlementvalue;
    public Action First;
    public Action Pige;
    public List<Sprite> digitSprites = new List<Sprite>(10);
    public Image tensDigitImage; 
    public Image unitsDigitImage; 
    public GameObject digitContainer; 
    public Image tensDigitImagee; 
    public Image unitsDigitImagee; 
    public GameObject digitContainere;
    public Image tensDigitImageg;
    public Image unitsDigitImageg;
    public GameObject digitContainerg;
    public Image tensDigitImageh;
    public Image unitsDigitImageh;
    public GameObject digitContainerh;
    public Action Chu;
    public Action Qi;
    public Action Ke;
    public Action Bu;
    private void Start()
    {
        Instance = this;
        DanCiFScore = PlayerPrefs.GetInt("Thehighestrecord");
        //DanCiFScoreTXT.text = ": " + (DanCiFScore);
        FindObjectOfType<Reboot>().RebootL += Zero;
        PlayerPrefs.Save();
        missCount = 1;
    }

    public void Zero()
    {
        Debug.Log("发生清零");
        correctCount = 0;
        errorCount = 0;
        missCount = 1;
        UpdateCorrectText(0);
        UpdateErrorText(0);
        UpdateMissText(0);
        Unrated = true;
    }
    private void Update()
    {
        DanCiFScore = PlayerPrefs.GetInt("Thehighestrecord");
        if (correctCount-errorCount >= DanCiFScore)//判定是否要更新最高分
        {
            DanCiFScore = correctCount-errorCount;
            PlayerPrefs.SetInt("Thehighestrecord", DanCiFScore);
           // DanCiFScoreTXT.text = "正确: " + (DanCiFScore);
        }
        if(missCount == Settlementvalue)
        {
            if (Unrated)
            {
                Debug.Log("进行结算");
                Finishes("1");
            }
        }
    }
    public void Billing(int Value)
    {
        Debug.Log(666);
        Settlementvalue = Value;
        Unrated = true;
    }
    public void Vibration()
    {
        // float timer = 0.5f;
#if UNITY_EDITOR
        Handheld.Vibrate();
#endif

    }

    public Text damageTextPrefab; // 伤害数字的预制体
    public Transform damageTextParent; // 被伤害

    public void ShowDamage(float damage)
    {
        Debug.Log(12334);
        Text damageText = Instantiate(damageTextPrefab, damageTextParent);
        damageText.text = damage.ToString();
        Destroy(damageText.gameObject, 1.0f); // 1秒后销毁
    }


public void UpdateCorrectText(int Count)
    {
        First();
        // ShowDamage(Count);
        correctCount += Count;
        //string numberStr = correctCount.ToString();
        //  correctText.text = "  " + (numberStr);
        UpdateNumber(1, correctCount);
    }

    public void UpdateErrorText(int Count)
    {
        Pige();
        Vibration();
        errorCount += Count;
      //  string numberStr = errorCount.ToString();
        // errorText.text = " " + (numberStr);
        UpdateNumber(2, errorCount);
    }
    public void UpdateMissText(int Count)
    {
        missCount += Count;
        string numberStr = missCount.ToString();
        //missText.text = "总计: " + (numberStr);
    }
    public void UpdateNumber(int option, int number)
    {
        if (option == 1)
        {
            if (number >= 0 && number <= 99)
            {
                digitContainer.SetActive(true);
                int tens = number / 10;
                if (tens > 0 && digitSprites[tens] != null)
                {
                    tensDigitImage.sprite = digitSprites[tens];
                    tensDigitImage.enabled = true;
                }
                else
                {
                    tensDigitImage.enabled = false;
                }

                int units = number % 10;
                if (digitSprites[units] != null)
                {
                    unitsDigitImage.sprite = digitSprites[units];
                    unitsDigitImage.enabled = true;
                }
            }
            else
            {
                digitContainer.SetActive(false);
                Debug.LogWarning("Number out of range (0-99)!");
            }
        }
        if (option == 2)
        {
            if (number >= 0 && number <= 99)
            {
                digitContainere.SetActive(true);

                int tens = number / 10;
                if (tens > 0 && digitSprites[tens] != null)
                {
                    tensDigitImagee.sprite = digitSprites[tens];
                    tensDigitImagee.enabled = true;
                }
                else
                {
                    tensDigitImagee.enabled = false;
                }

                int units = number % 10;
                if (digitSprites[units] != null)
                {
                    unitsDigitImagee.sprite = digitSprites[units];
                    unitsDigitImagee.enabled = true;
                }
            }
            else
            {
                digitContainere.SetActive(false);
                Debug.LogWarning("Number out of range (0-99)!");
            }
        }
        if (option == 3)
        {
            if (number >= 0 && number <= 99)
            {
                digitContainerg.SetActive(true);
                int tens = number / 10;
                if (tens > 0 && digitSprites[tens] != null)
                {
                    tensDigitImageg.sprite = digitSprites[tens];
                    tensDigitImageg.enabled = true;
                }
                else
                {
                    tensDigitImageg.enabled = false;
                }
                int units = number % 10;
                if (digitSprites[units] != null)
                {
                    unitsDigitImageg.sprite = digitSprites[units];
                    unitsDigitImageg.enabled = true;
                }
            }
            else
            {
                digitContainere.SetActive(false);
                Debug.LogWarning("Number out of range (0-99)!");
            }
        }
        if (option == 4)
        {
            if (number >= 0 && number <= 99)
            {
                digitContainerh.SetActive(true);
                int tens = number / 10;
                if (tens > 0 && digitSprites[tens] != null)
                {
                    tensDigitImageh.sprite = digitSprites[tens];
                    tensDigitImageh.enabled = true;
                }
                else
                {
                    tensDigitImageh.enabled = false;
                }
                int units = number % 10;
                if (digitSprites[units] != null)
                {
                    unitsDigitImageh.sprite = digitSprites[units];
                    unitsDigitImageh.enabled = true;
                }
            }
            else
            {
                digitContainere.SetActive(false);
                Debug.LogWarning("Number out of range (0-99)!");
            }
        }
    }

    public void Finishes(string level) 
    {
        correctCount -= errorCount;
        int Score = correctCount;
        if (Score < 0)
        {
            Score = 0;
        }
        
        PlayerPrefs.SetInt(level, Score);
        PlayerPrefs.Save();
       // DanCiFScoreTXT.text = " " +(DanCiFScore);

        // ZcorrectText.text = " " + (Score);
        UpdateNumber(3 ,Score);
        UpdateNumber(4, DanCiFScore);
        Debug.Log(Score);
        if(Score >= 15)
        {
            Settlement.Instance.ThreestarsClearance();
            Unrated = false;
        }
        else
        {
                if(Score >= 10)
                {
                Settlement.Instance.TwostarsClearance();
                Unrated = false;
                }
              else 
              {
                if (Score >= 5)
                {
                    Settlement.Instance.OnestarClearance();
                    Unrated = false;
                }
                else 
                {
                    Settlement.Instance.Clearance();                      
                }
              }
        }
            
        
    }
    int Chuyu = 0;
    int Kehuishou = 0;
    int Qita = 0;
    int Youhai = 0;
    public void Continuous(int Rese)
    {
        if (Rese == 1)
        {
            Chuyu += 1;
            Kehuishou = 0;
            Qita = 0;
            Youhai = 0;
            if (Chuyu == 3)
            {
                Chu();
                Debug.Log(45);
            }
        }
        if (Rese == 2)
        {
            Chuyu = 0;
            Kehuishou += 1;
            Qita = 0;
            Youhai = 0;
            if (Kehuishou == 3)
            {
                Ke();
                Debug.Log(45);
            }
        }
        if (Rese == 3)
        {
            Chuyu = 0;
            Kehuishou = 0;
            Qita += 1;
            Youhai = 0;
            if (Qita == 3)
            {
                Qi();
                Debug.Log(45);
            }
        }
        if (Rese == 4)
        {
            Chuyu = 0;
            Kehuishou = 0;
            Qita = 0;
            Youhai += 1;
            if (Youhai == 3)
            {
                Bu();
                Debug.Log(45);
            }
        }
    }
}
