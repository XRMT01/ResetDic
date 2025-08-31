using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsManager : MonoBehaviour
{
    private static LoadsManager _instance;
    private Action _action;
    public static LoadsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("LoadsManager");
                _instance = obj.AddComponent<LoadsManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }
    public void LoadScene(string sceneName)
    {
        _LoadScene(sceneName);
        SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(string sceneName,Action action)
    {
        _LoadScene(sceneName);
        _action = action;
    }
    private void _LoadScene(string sceneName) 
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        int displayProgress = 0;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        // 计算目标进度（将0.9f映射到100%）
        float targetProgress = 0.9f;
        float maxDisplayProgress = 100;

        while (asyncLoad.progress < targetProgress)
        {
            // 将实际进度映射到0-100%
            int toProgress = (int)(asyncLoad.progress / targetProgress * maxDisplayProgress);

            // 逐步更新进度条
            while (displayProgress < toProgress)
            {
                displayProgress++;
                UpdateLoadingUI(displayProgress);
                yield return new WaitForSeconds(0.01f); // 控制更新速度
            }
            yield return null;
        }

        // 确保进度条达到100%
        while (displayProgress < maxDisplayProgress)
        {
            displayProgress++;
            UpdateLoadingUI(displayProgress);
            yield return new WaitForSeconds(0.01f);
        }

        // 激活场景
        asyncLoad.allowSceneActivation = true;

        // 加载完成，执行回调
        if (_action != null)
        {
            _action.Invoke();
            _action = null;
        }
    }

    private void UpdateLoadingUI(int progress)
    {
        if (MainController.Instance != null &&
            MainController.Instance.MainViews != null)
        {
            MainController.Instance.MainViews.slider_Loading.value = progress;
            MainController.Instance.MainViews.text_Loading.text = $"{progress}%";
        }
    }
}