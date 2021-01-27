using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 lastCheckPointPos;

    public Checkpoint checkpoint00;
    public Checkpoint checkpoint01;
    public Checkpoint checkpoint02;
    public Checkpoint checkpoint03;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }

        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            lastCheckPointPos = checkpoint00.transform.position;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lastCheckPointPos = checkpoint01.transform.position;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lastCheckPointPos = checkpoint02.transform.position;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            lastCheckPointPos = checkpoint03.transform.position;
            SceneManager.LoadScene(0);
        }


    }
}
