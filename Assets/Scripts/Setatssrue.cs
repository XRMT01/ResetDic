using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Setatssrue : MonoBehaviour
{
    //此脚本为场景2所需
    public static Setatssrue Instance;
    public int Bengdi;
    public int DanCiFScore;
    public List<Sprite> digitSprites = new List<Sprite>(10);
    public Image tensDigitImage;
    public Image unitsDigitImage;
    public GameObject digitContainer;
    public Image tensDigitImagee;
    public Image unitsDigitImagee;
    public GameObject digitContainere;
    public GameObject Onestar;
    public GameObject Twostars;
    public GameObject Threestars;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

    }
    public void Update()
    {
        DanCiFScore = PlayerPrefs.GetInt("Thehighestrecord");
        Bengdi = PlayerPrefs.GetInt("1");
    }
    public void Kaishi()
    {
        UpdateNumber(1, Bengdi);
        UpdateNumber(2, DanCiFScore);
    }
    public void Stars()
    {
        int Score = Bengdi;
        if (Score >= 15)
        {
            ThreestarsClearance();
        }
        else
        {
            if (Score >= 10)
            {
                TwostarsClearance();
            }
            else
            {
                if (Score >= 5)
                {
                    OnestarClearance();
                }
                else
                {
                    Clearance();
                }
            }
        }
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
    }


    public void OnestarClearance()
    {
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);
        Onestar.SetActive(true);
    }
    public void TwostarsClearance()
    {
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);        
        Onestar.SetActive(true);
        Twostars.SetActive(true);
    }
    public void ThreestarsClearance()
    {
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);        
        Onestar.SetActive(true);
        Twostars.SetActive(true);
        Threestars.SetActive(true);
    }
    public void Clearance()
    {
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);
    }
}
