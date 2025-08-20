using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public GameObject Tishi;
    public GameObject My;
    public float fallSpeed = 5.0f; // 下落速度
    public float LfallSpeed = 0; // 零食速度
    public float BuffSpeed = 1; // 减速速度
    private bool isDragging = false;
    private Vector3 dragOrigin; // 拖拽开始时的物体位置
    private Rigidbody2D rb;
    public string correctTag = "CorrectTag";
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private float initialX;
    public bool hasActivated = true;
    public bool SuspendedT = false;
    private bool isTouching;
    public bool Around = true;
    public bool Leftandrightmode = false;
    public bool Jiansubuff = false;

    //public Action<WasteBtnType> OnClickWaste;
    void Start()
    {
        if (RandomPrefab.Instance.Shenchansu)
        {
            Jiansubuff = false;
        }
        else 
        {
            Jiansubuff = true;
        }

        initialX = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Item item = new Item(1.2.QT.p );
        FindObjectOfType<Switch>().Pause += Suspended;
        FindObjectOfType<Switch>().Runtime += Functioning;
        FindObjectOfType<Reboot>().RebootL += Purge;
        FindObjectOfType<Buttonleft>().LeftAction += FTranslation;
        FindObjectOfType<Buttonright>().RightAction += Translation;
        FindObjectOfType<Switch>().Zanhuansud += Jiansu;
        FindObjectOfType<Switch>().HfZanhuansud += Fuyuan;

        // OnClickWaste += OnclickWaste;
    }

   /* private void OnclickWaste(WasteBtnType type)
    {
        switch (type) 
        {
            case WasteBtnType.Left:
                FTranslation();
                break;
            case WasteBtnType.Right:
                Translation();
                break;
        }
    }*/

    public void Purge() 
    {
        Destroy(My);
    }
    public void Jiansu()
    {
        Jiansubuff = true;
    }
    public void Fuyuan()
    {
        Jiansubuff = false;
    }
    void OnMouseDown()
    {
        // 当鼠标按下时，开始拖拽并记录拖拽开始时的位置
        isDragging = true;
        Switch.Instance.Zanhuanjinsu();
        dragOrigin = transform.position;
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
        spriteRenderer.sortingOrder = 5;
    }
    
    public void Suspended() 
    {

        SuspendedT = true;
        isDragging = true;
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
         //   Debug.Log(1111111);
    }
    
    public void Functioning()
    {
        SuspendedT = false;
        isDragging = false;
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
            Debug.Log(2222222);
    }

    void OnMouseUp()
    {
        spriteRenderer.sortingOrder = 1;
        Switch.Instance.HfyZanhuanjinsu();
        // 当鼠标松开时，结束拖拽并恢复下落
        isDragging = false;
        if (boxCollider != null)
        {

            boxCollider.enabled = true;
        }
    }

    public void Translation()
    {
        Debug.Log(111);
        if (Leftandrightmode)
        {
            Vector2 currentPosition = transform.position;
            currentPosition.x += 1.2f;
            transform.position = currentPosition;
            isDragging = false;

        }
    }
    public void FTranslation()
    {
        Debug.Log(11);
        if (Leftandrightmode)
        {
            Vector2 currentPosition = transform.position;
            currentPosition.x += -1.2f;
            transform.position = currentPosition;
            isDragging = false;
        }
    }
    void Update()
    {
        if (!hasActivated)
        {
            
            float currentX = transform.position.x;
            float deltaX = currentX - initialX;

            if (Mathf.Abs(deltaX) > 0.4f)
            {
                isDragging = false;
                float direction = Mathf.Sign(deltaX);
                transform.Translate(direction * 1.2f, 0f, 0f);
                boxCollider.enabled = true;
                hasActivated = true; 
            }
        }
        if (!isDragging)
        {
            if (!Jiansubuff)
            {
                // 如果不是拖拽状态，则让物体下落
                Vector3 newPosition = transform.position;
                newPosition.y -= fallSpeed * Time.deltaTime;
                transform.position = newPosition;
            }
            else
            {
                Vector3 newPosition = transform.position;
                newPosition.y -= BuffSpeed * Time.deltaTime;
                transform.position = newPosition;
            }
            
        }
        else
        {
            if (!SuspendedT)
            {
                // 如果是拖拽状态，则更新物体位置以跟随鼠标（这里可以添加一些平滑跟随效果，但为了简单直接设置位置）
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                transform.position = mousePosition;
                rb.velocity = Vector2.zero;
            }
            else
            {
                Vector3 newPosition = transform.position;
                newPosition.y -= LfallSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Around)
        {
            if (other.CompareTag("Judgmentarea"))
            {
                Leftandrightmode = true;
                Around = false;
            }
        }
        else
        {
            if (other.CompareTag("Judgmentarea"))
            {
                Debug.Log('3');
            }
            if (correctTag == "Recyclablegarbage")
            {
                if (other.CompareTag(correctTag))
                {
                    UImanager.Instance.Continuous(2);
                    //Tishi.SetActive(false);
                    UImanager.Instance.UpdateMissText(1);
                    RSoundSanagement.Instance.RecyclingSoundSanagement(1);
                    UImanager.Instance.UpdateCorrectText(1);
                    gameObject.SetActive(false);

                }
                else
                {
                    if (other.CompareTag("Nothingness"))
                    {
                        UImanager.Instance.UpdateMissText(1);
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        UImanager.Instance.UpdateMissText(1);
                        RSoundSanagement.Instance.RecyclingSoundSanagement(0);
                        UImanager.Instance.UpdateErrorText(1);
                        gameObject.SetActive(false);
                    }

                }
            }
            if (correctTag == "Foodwaste")
            {
                if (other.CompareTag(correctTag))
                {
                    UImanager.Instance.Continuous(1);
                    RSoundSanagement.Instance.FecyclingSoundSanagement(1);
                    UImanager.Instance.UpdateCorrectText(1);
                    UImanager.Instance.UpdateMissText(1);
                    gameObject.SetActive(false);

                }
                else
                {
                    if (other.CompareTag("Nothingness"))
                    {
                        UImanager.Instance.UpdateMissText(1);
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        UImanager.Instance.UpdateMissText(1);
                        RSoundSanagement.Instance.FecyclingSoundSanagement(0);
                        UImanager.Instance.UpdateErrorText(1);
                        gameObject.SetActive(false);
                    }

                }
            }
            if (correctTag == "Nonrecyclablegarbage")
            {
                if (other.CompareTag(correctTag))
                {
                    UImanager.Instance.Continuous(4);
                    //Tishi.SetActive(false);
                    UImanager.Instance.UpdateMissText(1);
                    RSoundSanagement.Instance.RecyclingSoundSanagement(1);
                    UImanager.Instance.UpdateCorrectText(1);
                    gameObject.SetActive(false);

                }
                else
                {
                    if (other.CompareTag("Nothingness"))
                    {
                        UImanager.Instance.UpdateMissText(1);
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        UImanager.Instance.UpdateMissText(1);
                        RSoundSanagement.Instance.RecyclingSoundSanagement(0);
                        UImanager.Instance.UpdateErrorText(1);
                        gameObject.SetActive(false);
                    }

                }
            }
            if (correctTag == "Othergarbage")
            {
                if (other.CompareTag(correctTag))
                {
                    UImanager.Instance.Continuous(3);
                    RSoundSanagement.Instance.FecyclingSoundSanagement(1);
                    UImanager.Instance.UpdateCorrectText(1);
                    UImanager.Instance.UpdateMissText(1);
                    gameObject.SetActive(false);

                }
                else
                {
                    if (other.CompareTag("Nothingness"))
                    {
                        UImanager.Instance.UpdateMissText(1);
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        UImanager.Instance.UpdateMissText(1);
                        RSoundSanagement.Instance.FecyclingSoundSanagement(0);
                        UImanager.Instance.UpdateErrorText(1);
                        gameObject.SetActive(false);
                    }

                }
            }
        }
        
    }

}