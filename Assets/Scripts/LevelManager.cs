/*using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // 关卡数值键名
    private const string LEVEL_VALUE_KEY = "LevelValue";
    public static LevelManager Instance;
    void Start()
    {

        Instance = this;
    }
        // 进入关卡时调用
        public void EnterLevel(int levelIndex)
    {
        // 保存当前关卡索引
        PlayerPrefs.SetInt("CurrentLevel", levelIndex);

        // 初始化或增加关卡数值
        int currentValue = PlayerPrefs.GetInt(LEVEL_VALUE_KEY + levelIndex, 0);
        PlayerPrefs.SetInt(LEVEL_VALUE_KEY + levelIndex, currentValue + 1);

        // 加载关卡场景
        //SceneManager.LoadScene("Level_" + levelIndex);
    }

    // 在关卡场景中获取当前关卡数值
    public static int GetCurrentLevelValue()
    {
        int levelIndex = PlayerPrefs.GetInt("CurrentLevel", 1);
        return PlayerPrefs.GetInt(LEVEL_VALUE_KEY + levelIndex, 0);
    }
}
*/