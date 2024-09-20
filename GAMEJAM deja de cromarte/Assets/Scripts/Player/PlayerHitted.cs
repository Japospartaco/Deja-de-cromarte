using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitted : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Si ha habido una colisión con el objeto "OtherObject", enviamos una señal al script "MyOtherScript"
            Debug.Log("Holiwis!");
            GameObject myObject = GameObject.Find("EventSystem");
            if (myObject != null)
			{
                Timer myScript = myObject.GetComponent<Timer>();
                if (myScript != null)
				{
                    //Daño del enemigo aquí
                    myScript.UpdateTimerOnHit(6);
                }
			}
        }
    }
}
