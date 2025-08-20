using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager1 : MonoBehaviour
{
    public static LevelManager1 Instance;

    private int currentLevel;
    private float difficulty;
    public int Level = 1;
    public int level = 1;
    public int Levelf;
    void Awake()
    {

        Instance = this;
        DontDestroyOnLoad(gameObject);

        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        difficulty = 1 + (currentLevel * 0.15f);
        Level = currentLevel;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public float GetDifficulty()
    {
        return difficulty;
    }
    public void GetDint(int guanka)
    {
        level = guanka;
    }

    public void CompleteLevel()
    {

        PresetButtonGenerator.UnlockNextLevel(Level);
        Level += 1;
    }
    public void Jixumaoxian()
    {
        Levelf = level;
        PlayerPrefs.SetInt("CurrentLevel", Levelf);
        SceneManager.LoadScene("SamesceneN");
    }
}