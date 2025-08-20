using UnityEngine;
using UnityEngine.UI;


public class KaiguanZd : MonoBehaviour
{
    public RectTransform imageRect; // 需要移动的图片的 RectTransform
    private Vector2 originalPosition; // 记录图片的原始位置
    private bool isMoved = false;     // 记录图片当前是否已移动

    void Start()
    {
        // 记录图片的初始位置
        if (imageRect != null)
        {
            originalPosition = imageRect.localPosition;
        }
    }

    public void ToggleImagePosition()
    {
        if (imageRect != null)
        {
            if (isMoved)
            {
                // 图片已移动，返回原位
                imageRect.localPosition = originalPosition;
            }
            else
            {
                // 图片未移动，向右移动 50 个单位
                imageRect.localPosition = originalPosition + new Vector2(136, 0);
            }
            isMoved = !isMoved; // 切换状态
        }
    }
}
