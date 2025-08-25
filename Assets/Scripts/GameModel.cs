using System;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    // 游戏数据
    public int correctCount { get; private set; }
    public int errorCount { get; private set; }
    public int missCount { get; private set; }
    public int DanCiFScore { get; private set; }
    public bool Unrated { get; set; }
    public string Thehighestrecord { get; private set; }
    public int Settlementvalue { get; set; }

    // 连续计数
    private int Chuyu = 0;
    private int Kehuishou = 0;
    private int Qita = 0;
    private int Youhai = 0;

    // 事件
    public Action First;
    public Action Pige;
    public Action Chu;
    public Action Qi;
    public Action Ke;
    public Action Bu;

    private static GameModel instance;
    public static GameModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameModel>();
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

    private void Start()
    {
        DanCiFScore = PlayerPrefs.GetInt("Thehighestrecord");
        missCount = 1;
        Unrated = true;

        FindObjectOfType<Reboot>().RebootL += Zero;
        PlayerPrefs.Save();
    }

    public void Zero()
    {
        Debug.Log("发生清零");
        correctCount = 0;
        errorCount = 0;
        missCount = 1;
        Unrated = true;

        // 通知视图更新
        UIManager.Instance.UpdateCorrectText(0);
        UIManager.Instance.UpdateErrorText(0);
        UIManager.Instance.UpdateMissText(0);
    }

    public void UpdateScores()
    {
        // 更新最高分
        if (correctCount - errorCount >= DanCiFScore)
        {
            DanCiFScore = correctCount - errorCount;
            PlayerPrefs.SetInt("Thehighestrecord", DanCiFScore);
        }

        // 检查是否需要结算
        if (missCount == Settlementvalue && Unrated)
        {
            Debug.Log("进行结算");
            Finishes("1");
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
#if UNITY_EDITOR
        Handheld.Vibrate();
#endif
    }

    public void UpdateCorrectCount(int Count)
    {
        First?.Invoke();
        correctCount += Count;
    }

    public void UpdateErrorCount(int Count)
    {
        Pige?.Invoke();
        Vibration();
        errorCount += Count;
    }

    public void UpdateMissCount(int Count)
    {
        missCount += Count;
    }

    public void Finishes(string level)
    {
        int finalScore = correctCount - errorCount;
        if (finalScore < 0)
        {
            finalScore = 0;
        }

        PlayerPrefs.SetInt(level, finalScore);
        PlayerPrefs.Save();

        // 通知视图更新结算信息
        UIManager.Instance.UpdateNumber(3, finalScore);
        UIManager.Instance.UpdateNumber(4, DanCiFScore);
        Debug.Log(finalScore);

        // 处理星级评定
        if (finalScore >= 15)
        {
            Settlement.Instance.ThreestarsClearance();
            Unrated = false;
        }
        else if (finalScore >= 10)
        {
            Settlement.Instance.TwostarsClearance();
            Unrated = false;
        }
        else if (finalScore >= 5)
        {
            Settlement.Instance.OnestarClearance();
            Unrated = false;
        }
        else
        {
            Settlement.Instance.Clearance();
        }
    }

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
                Chu?.Invoke();
                Debug.Log(45);
            }
        }
        else if (Rese == 2)
        {
            Chuyu = 0;
            Kehuishou += 1;
            Qita = 0;
            Youhai = 0;
            if (Kehuishou == 3)
            {
                Ke?.Invoke();
                Debug.Log(45);
            }
        }
        else if (Rese == 3)
        {
            Chuyu = 0;
            Kehuishou = 0;
            Qita += 1;
            Youhai = 0;
            if (Qita == 3)
            {
                Qi?.Invoke();
                Debug.Log(45);
            }
        }
        else if (Rese == 4)
        {
            Chuyu = 0;
            Kehuishou = 0;
            Qita = 0;
            Youhai += 1;
            if (Youhai == 3)
            {
                Bu?.Invoke();
                Debug.Log(45);
            }
        }
    }
}
