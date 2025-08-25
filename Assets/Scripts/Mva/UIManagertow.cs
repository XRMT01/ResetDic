using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
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

    private void Update()
    {
        GameModel.Instance.UpdateScores();
    }

    // 以下方法作为View和Model之间的桥梁
    public void UpdateCorrectText(int Count)
    {
        GameModel.Instance.UpdateCorrectCount(Count);
        UIView.Instance.UpdateNumber(1, GameModel.Instance.correctCount);
    }

    public void UpdateErrorText(int Count)
    {
        GameModel.Instance.UpdateErrorCount(Count);
        UIView.Instance.UpdateNumber(2, GameModel.Instance.errorCount);
    }

    public void UpdateMissText(int Count)
    {
        GameModel.Instance.UpdateMissCount(Count);
        string numberStr = GameModel.Instance.missCount.ToString();
        // UIView.Instance.missText.text = "总计: " + (numberStr);
    }

    public void UpdateNumber(int option, int number)
    {
        UIView.Instance.UpdateNumber(option, number);
    }

    public void ShowDamage(float damage)
    {
        UIView.Instance.ShowDamage(damage);
    }

    // 转发方法到Model
    public void Billing(int Value) => GameModel.Instance.Billing(Value);
    public void Vibration() => GameModel.Instance.Vibration();
    public void Finishes(string level) => GameModel.Instance.Finishes(level);
    public void Continuous(int Rese) => GameModel.Instance.Continuous(Rese);
    public void Zero() => GameModel.Instance.Zero();
}