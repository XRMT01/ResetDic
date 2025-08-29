using System;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    private static EventCenter _instance;
    public static EventCenter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("EventCenter").AddComponent<EventCenter>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    public delegate void EventDelegate();
    private Dictionary<string, EventDelegate> _eventTable = new Dictionary<string, EventDelegate>();

    public static void AddListener(string eventName, EventDelegate listener)
    {
        Instance._AddListener(eventName, listener);
    }

    public static void RemoveListener(string eventName, EventDelegate listener)
    {
        Instance._RemoveListener(eventName, listener);
    }

    public static void TriggerEvent(string eventName)
    {
        Instance._TriggerEvent(eventName);
    }

    private void _AddListener(string eventName, EventDelegate listener)
    {
        if (!_eventTable.ContainsKey(eventName))
            _eventTable[eventName] = null; // 初始化为 null，而不是 new EventDelegate()

        _eventTable[eventName] += listener;
    }

    private void _RemoveListener(string eventName, EventDelegate listener)
    {
        if (_eventTable.ContainsKey(eventName))
        {
            _eventTable[eventName] -= listener;
        }
    }

    private void _TriggerEvent(string eventName)
    {
        if (_eventTable.ContainsKey(eventName))
        {
            _eventTable[eventName]?.Invoke();
        }
    }
}