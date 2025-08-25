using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    // 文本元素
    public Text correctText;
    public Text errorText;
    public Text missText;
    public Text ZcorrectText;
    public Text DanCiFScoreTXT;
    public Text damageTextPrefab;

    // 数字显示相关
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

    // 父物体
    public Transform damageTextParent;

    private static UIView instance;
    public static UIView Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIView>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowDamage(float damage)
    {
        Debug.Log(12334);
        Text damageText = Instantiate(damageTextPrefab, damageTextParent);
        damageText.text = damage.ToString();
        Destroy(damageText.gameObject, 1.0f);
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
        else if (option == 2)
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
        else if (option == 3)
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
        else if (option == 4)
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
}
