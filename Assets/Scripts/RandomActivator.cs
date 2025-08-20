using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 在Inspector面板中拖入三个物体

    void Start()
    {
        FindObjectOfType<Reboot>().RebootL += ActivateRandomObject;

        if (objectsToActivate.Length != 2)
        {
            Debug.LogError("确");
            return;
        }
        ActivateRandomObject();
    }

    public void ActivateRandomObject()
    {
        // 先禁用所有物体
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }

        int randomIndex = Random.Range(0, 2);

        // 激活选中的物体
        objectsToActivate[randomIndex].SetActive(true);
    }
}
