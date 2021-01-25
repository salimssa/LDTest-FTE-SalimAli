using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public enum OpenOn {Left, Right};
    public OpenOn sideOpen;

    public KeyCode testSwitch;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(testSwitch))
        {
            SwitchState();
        }
    }


    void SwitchState()
    {
        if (sideOpen == OpenOn.Left)
        {
            //then I want to open right
            transform.Rotate(new Vector3 (0.0f, 0.0f, -1.0f), -90.0f);
            sideOpen = OpenOn.Right;
        }
        else
        {
            //then I want to open left
            transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f), 90.0f);
            sideOpen = OpenOn.Left;
        }

    }
}
