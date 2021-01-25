using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector3D : MonoBehaviour
{
    public Vector3 effectorForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(effectorForce);

    }
}
