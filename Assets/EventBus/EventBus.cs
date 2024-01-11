using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus
{
    public static Dictionary<string, UnityEvent> events;

    private static UnityEvent RegisterEvent(string eventName){
        if (events == null) events = new Dictionary<string, UnityEvent>();
        if (events.ContainsKey(eventName)) return events[eventName];
        events.Add(eventName, new UnityEvent());
        return events[eventName];
    }

    public static void CallEvent(string eventName){
        RegisterEvent(eventName).Invoke();
    }

    public static UnityEvent GetEvent(string eventName){
        return RegisterEvent(eventName);
    }
}
