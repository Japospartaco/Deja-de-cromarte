using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;


    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        if (!(Input.GetKey("w")|| Input.GetKey("s")))
        {
            gameObject.GetComponent<Animator>().SetBool("upDown", false);
        }

        if (!(Input.GetKey("a") || Input.GetKey("d")))
        {
            gameObject.GetComponent<Animator>().SetBool("leftRight", false);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Input.GetKey("w"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);
            gameObject.GetComponent<Animator>().SetBool("upDown",true);
        }
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * -speed, transform.position.y, transform.position.z);
            gameObject.GetComponent<Animator>().SetBool("leftRight", true);
            if(gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetKey("s"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * -speed, transform.position.z);
            gameObject.GetComponent<Animator>().SetBool("upDown", true);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
            gameObject.GetComponent<Animator>().SetBool("leftRight", true);
        }

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        
    }

    void Move()
    {
        
    }

}
