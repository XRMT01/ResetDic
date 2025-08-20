using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ButtonPosition
{
    public float x;
    public float y;
}

public class PresetButtonGenerator : MonoBehaviour
{
    public Canvas canvas;
    public GameObject buttonPrefab;
    public List<Vector2> presetButtonPositions = new List<Vector2>();
    public string levelSceneName = "LevelScene";
    public string levelDataKey = "HighestLevel";

    private int highestUnlockedLevel = 1;

    void Start()
    {
        if (canvas == null || buttonPrefab == null)
        {
            Debug.LogError("必要组件未设置");
            return;
        }

        highestUnlockedLevel = PlayerPrefs.GetInt(levelDataKey, 1);
        GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        for (int i = 0; i < presetButtonPositions.Count; i++)
        {
            int levelNumber = i + 1;
            Vector2 position = presetButtonPositions[i];

            GameObject button = Instantiate(buttonPrefab, canvas.transform);
            RectTransform rt = button.GetComponent<RectTransform>();
            rt.anchoredPosition = position;

            Button btn = button.GetComponent<Button>();
            btn.interactable = (levelNumber <= highestUnlockedLevel);
            btn.onClick.AddListener(() => LoadLevel(levelNumber));

            Text btnText = button.GetComponentInChildren<Text>();
            if (btnText != null)
            {
                btnText.text = $"Level {levelNumber}";
            }
        }
    }

    void LoadLevel(int level)
    {
        LevelManager1.Instance.GetDint(level);
    }

    public static void UnlockNextLevel(int currentLevel)
    {
        int highest = PlayerPrefs.GetInt("HighestLevel", 1);
        if (currentLevel >= highest)
        {
            PlayerPrefs.SetInt("HighestLevel", currentLevel + 1);
        }
    }
}
