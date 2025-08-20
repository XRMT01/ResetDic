using UnityEngine.UI;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    // 引用滚动条组件
    public Slider volumeSlider;

    // 引用所有需要控制的音频源
    public AudioSource[] audioSources;
        
    public float value;

    void Start()
    {
        // 确保滚动条和音频源都已设置
        if (volumeSlider == null)
        {
            Debug.LogError("VolumeScrollbar is not assigned.");
            return;
        }

        if (audioSources == null || audioSources.Length == 0)
        {
            Debug.LogError("No AudioSources assigned.");
            return;
        }

        // 初始化音频源的音量（可选，根据需要）
        SetVolume(volumeSlider.value);

        // 添加滚动条值改变事件的监听器
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void OnDestroy()
    {
        // 移除滚动条值改变事件的监听器，防止内存泄漏
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
        }
    }

    // 设置所有音频源的音量
    void SetVolume(float value)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = value;
        }
    }
}