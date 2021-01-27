using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : MonoBehaviour
{
    public GameObject[] healthPlanks;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = healthPlanks.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LooseOneHealth()
    {
        healthPlanks[health-1].SetActive(false);
        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
