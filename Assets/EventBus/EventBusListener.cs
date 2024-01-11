using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBusListener : MonoBehaviour
{
    [SerializeField] private string eventName;
    public UnityEvent OnEventRaised;

    private void Awake()
    {
        EventBus.GetEvent(eventName).AddListener(EventRaised);
    }

    private void EventRaised(){
        OnEventRaised.Invoke();
    }

}
