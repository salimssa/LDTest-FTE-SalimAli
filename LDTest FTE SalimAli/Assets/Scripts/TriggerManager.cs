using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] private UnityEvent thisTriggerEnter;
    [SerializeField] private UnityEvent thisTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thisTriggerEnter.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thisTriggerExit.Invoke();
        }

    }

}
