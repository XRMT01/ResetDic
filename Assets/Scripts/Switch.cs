using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public static Switch Instance;
    public GameObject Setup;
    public GameObject Setupt;
    public GameObject Setupo;
    public GameObject Penll;
    public event Action Pause;
    public event Action Runtime;
    public event Action Zanhuansud;
    public event Action HfZanhuansud;

    void Start()
    {
        Instance = this;
    }

    public void gays()
    {
        Pause();
    }
    public void gaysd()
    {
        Penll.SetActive(false);
        Debug.Log(23131);
        RandomPrefab.Instance.Currej();
        Runtime();
    }

    public void KSetup()
    {
        Pause();
        Setup.SetActive(true);
        Setupo.SetActive(true);
        Setupt.SetActive(false);
    }
    public void GSetup()
    {
        Runtime();
        Setup.SetActive(false);
        Setupo.SetActive(true);
        Setupt.SetActive(false);
    }
    public void Setuptd()
    {
        Setupo.SetActive(false);
        Setupt.SetActive(true);
    }
    public void Setuptdt()
    {
        Setup.SetActive(true);
        Setupo.SetActive(false);
        Setupt.SetActive(true);
    }
    public void GSetupt()
    {

        Setup.SetActive(false);
        Setupt.SetActive(false);
    }
    public void Zanhuanjinsu() 
    {
        Zanhuansud();
    }
    public void HfyZanhuanjinsu()
    {
        HfZanhuansud();
    }
    public void qh()
    {
        LevelManager1.Instance.CompleteLevel();
        SceneManager.LoadScene("SampleSceneL");
    }

    // ÍË³öÓÎÏ·
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(1);
    }
}
