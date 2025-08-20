using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public GameObject pp;
    // 添加两个新的 GameObject 变量
    public GameObject pp2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ks()
    {
        // 激活所有 GameObject
        pp.SetActive(true);
        if (pp2 != null) pp2.SetActive(true);
        Invoke("qh", 3f);
    }

    public void qh() 
    {
        SceneManager.LoadScene("SampleSceneL");
    }
}