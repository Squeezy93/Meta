using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public event Action<Collider> OnTriggerEnterEvent = delegate { };
    public event Action<Collider> OnTriggerExitEvent = delegate { };
    public event Action<Collider> OnTriggerStayEvent = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitEvent.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerStayEvent.Invoke(other);
    }
}
