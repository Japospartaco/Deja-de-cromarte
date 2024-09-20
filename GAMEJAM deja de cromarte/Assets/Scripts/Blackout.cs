using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Blackout : MonoBehaviour
{
    public GameObject blackout;
    public Movement movement;
    public Shooting shooting;
    public int estado = 0; //0 mirar, 1 andar, 2 disparar

    void Start()
    {
        blackout.SetActive(false);
        movement.enabled = false;
        shooting.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (estado == 2)
            {
                estado = 0;
            }
            else
            {
                estado++;
            }
            State();
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (estado == 0)
            {
                estado = 2;
            }
            else
            {
                estado--;
            }
            State();
        }
    }

    void State()
    {
        transform.rotation = new Quaternion (0, 0, 0,0);
        if (estado == 0)//Mirar
        {
            print("Mirar");
            gameObject.GetComponent<Animator>().SetBool("shoot", false);
            gameObject.GetComponent<Animator>().SetBool("upDown", false);
            gameObject.GetComponent<Animator>().SetBool("leftRight", false);
            gameObject.GetComponent<Animator>().SetBool("look", true);
            blackout.SetActive(false);
            movement.enabled = false;
            shooting.enabled = false;
        }
        if (estado == 1)//Andar
        {
            print("Andar");
            gameObject.GetComponent<Animator>().SetBool("shoot", false);
            gameObject.GetComponent<Animator>().SetBool("upDown", false);
            gameObject.GetComponent<Animator>().SetBool("leftRight", false);
            gameObject.GetComponent<Animator>().SetBool("look", false);
            blackout.SetActive(true);
            movement.enabled = true;
            shooting.enabled = false;
        }
        if (estado == 2)//Disparar
        {
            gameObject.GetComponent<Animator>().SetBool("look", false);
            gameObject.GetComponent<Animator>().SetBool("upDown", false);
            gameObject.GetComponent<Animator>().SetBool("leftRight", false);
            gameObject.GetComponent<Animator>().SetBool("shoot", true);
            print("Disparar");
            blackout.SetActive(true);
            movement.enabled = false;
            shooting.enabled = true;
        }
    }
}
