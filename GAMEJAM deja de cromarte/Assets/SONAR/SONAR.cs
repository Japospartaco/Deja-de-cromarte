using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SONAR : MonoBehaviour
{
    public GameObject[] enemyArray;
    public GameObject[] signalers;
    public GameObject signalerPrefab;
    public GameObject Player;
    public Vector3 playerPos;
    public float clock;
    public bool turno = false;
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;

        if (!turno)
        {
            if (clock > 0.5)
            {
                int initial = 1;
                playerPos = Player.transform.position;
                enemyArray = GameObject.FindGameObjectsWithTag("enemy");
                initial = enemyArray.Length;
                signalers = new GameObject[initial];

                for (int i = 0; i < enemyArray.Length; i++)
                {
                    if (Vector3.Distance(playerPos, enemyArray[i].transform.position) <= 19)
                    {
                        GameObject signaler = Instantiate(signalerPrefab);
                        signalers[i] = signaler;
                        Vector3 newPos = (enemyArray[i].transform.position - playerPos) / 11 + transform.position;
                        //if(newPos.magnitude > 1)
                        //{
                        //    LayerMask mask = LayerMask.GetMask("SONAR");
                        //    RaycastHit2D hit = Physics2D.Raycast(newPos, transform.position, Mathf.Infinity, mask);
                        //    if(hit.collider != null)
                        //    {
                        //        newPos = hit.point;
                        //    }
                        //}
                        signaler.transform.position = new Vector3(newPos.x, newPos.y, -1);
                        signaler.transform.SetParent(transform);
                    }
                    
                }
                clock = 0;
                turno = true;
            }
        }
        else
        {
            if (clock > 0.5)
            {
                for (int i = 0; i < enemyArray.Length; i++)
                {
                    Destroy(signalers[i]);
                }
                clock = 0;
                turno = false;
            }
            
        }
        


    }
}
