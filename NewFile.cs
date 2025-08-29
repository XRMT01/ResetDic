private void _AddListener(string eventName, EventDelegate listener)
{
    if (!_eventTable.ContainsKey(eventName))
        _eventTable[eventName] = null; // 初始化为 null，而不是 new EventDelegate()

    _eventTable[eventName] += listener;
}