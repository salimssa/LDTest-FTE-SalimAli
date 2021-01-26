using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDropper : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropBody()
    {
        Instantiate(body, spawnPoint.position, Quaternion.identity);
        Debug.Log("Dropping Body");
    }

}
