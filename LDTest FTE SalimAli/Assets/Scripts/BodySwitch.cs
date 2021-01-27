using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodySwitch : MonoBehaviour
{
    public bool isInRange;
    //public KeyCode interactKey;
    public UnityEvent interactAction;

    public GameObject cover;
    private bool isActive;

    public BodyDropper linkedBodyDropper;

    // Start is called before the first frame update
    void Start()
    {
        cover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Interact") && isActive)
            {
                interactAction.Invoke();
            }
        }

        if (GameObject.FindWithTag("Follower") != null)
        {
            cover.SetActive(true);
            isActive = false;
        }
        else
        {
            cover.SetActive(false);
            isActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

}
