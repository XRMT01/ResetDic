using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour
{
    public static Settlement Instance;
    public GameObject KSettlement;
    public GameObject Onestar;
    public GameObject Twostars;
    public GameObject Threestars;
    public void OnestarClearance()
    {
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);
        KSettlement.SetActive(true);
        Onestar.SetActive(true);
    }
    public void TwostarsClearance()
    {
        LevelManager1.Instance.CompleteLevel();
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);
        KSettlement.SetActive(true);
        Onestar.SetActive(true);
        Twostars.SetActive(true);
    }
    public void ThreestarsClearance()
    {
        LevelManager1.Instance.CompleteLevel();
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);
        KSettlement.SetActive(true);
        Onestar.SetActive(true);
        Twostars.SetActive(true);
        Threestars.SetActive(true);
    }
    public void Clearance()
    {
        LevelManager1.Instance.CompleteLevel();
        Onestar.SetActive(false);
        Twostars.SetActive(false);
        Threestars.SetActive(false);
        KSettlement.SetActive(true);
    }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
