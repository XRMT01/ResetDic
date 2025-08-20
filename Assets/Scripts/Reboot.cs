using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Reboot : MonoBehaviour
{
    public event Action RebootL;
    public GameObject Pinfen;
    public GameObject Zanting;
    public GameObject Jiaoceh;
    public static Reboot Instance;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Zailai()
    {
        RebootL();
        Pinfen.SetActive(false);
        Zanting.SetActive(false);
        Jiaoceh.SetActive(true);

    }
    public void GSetup()
    {
       
       
    }
}
