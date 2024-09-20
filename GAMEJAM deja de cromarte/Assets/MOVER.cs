using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVER : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);
        }
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * -speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("s"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * -speed, transform.position.z);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
        }

    }

}
