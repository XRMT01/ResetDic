using System.Collections;
using System;
using UnityEngine;

public class Buttonleft : MonoBehaviour
{
    public Action LeftAction;
    public bool QYong;

    void OnMouseDown()
    {
        if (QYong)
        {
            LeftAction();
        }
    }
    // Start is called before the first frame u
    // }pdate
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
