using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] private UnityEvent thisTriggerEnter;
    [SerializeField] private UnityEvent thisTriggerExit;
    [SerializeField] private UnityEvent thisTriggerInteract;

    [SerializeField] private UnityEvent thisTriggerExitFollower;

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

        if (other.CompareTag("Follower"))
        {
            thisTriggerExitFollower.Invoke();
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                thisTriggerInteract.Invoke();
            }
        }

    }

}
