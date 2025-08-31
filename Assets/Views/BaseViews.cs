using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseViews : MonoBehaviour
{
    protected virtual void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize() { }

    protected virtual void OnEnable()
    {
        RegisterEvents();
    }

    protected virtual void OnDisable()
    {
        UnregisterEvents();
    }

    // 事件注册
    protected abstract void RegisterEvents();
    // 事件注销
    protected abstract void UnregisterEvents();
}
