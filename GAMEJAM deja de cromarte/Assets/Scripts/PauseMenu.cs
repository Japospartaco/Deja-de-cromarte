using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 0)
            {
                Debug.Log("Tiempo reanudado");
                Time.timeScale = 1;
                pause.SetActive(false);
            }
            else
            {
                Debug.Log("Tiempo parado");
                Time.timeScale = 0;
                pause.SetActive(true);
            }

        }
    }
}
