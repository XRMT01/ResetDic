using System.Collections;
using System;
using UnityEngine;

public class Buttonright : MonoBehaviour
{
    public Action RightAction;
    public bool QYong;
    // Start is called before the first frame update
    void OnMouseDown()
    {

        if (QYong)
        {


            RightAction.Invoke();



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
