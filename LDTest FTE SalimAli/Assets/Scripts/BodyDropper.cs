using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDropper : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject body;

    public BodySwitch InteractingSwitch;
    public bool spawnedBodyAlive = false;
    private GameObject spawnedBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedBody == null)
        {
            spawnedBodyAlive = false;
        }
    }

    public void DropBody()
    {
        spawnedBody = Instantiate(body, spawnPoint.position, Quaternion.identity);
        spawnedBodyAlive = true;
        Debug.Log("Dropping Body");
    }

}
