using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitted : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Si ha habido una colisi�n con el objeto "OtherObject", enviamos una se�al al script "MyOtherScript"
            Debug.Log("Holiwis!");
            GameObject myObject = GameObject.Find("EventSystem");
            if (myObject != null)
			{
                Timer myScript = myObject.GetComponent<Timer>();
                if (myScript != null)
				{
                    //Da�o del enemigo aqu�
                    myScript.UpdateTimerOnHit(6);
                }
			}
        }
    }
}
