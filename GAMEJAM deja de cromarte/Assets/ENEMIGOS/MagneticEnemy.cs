using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticEnemy : MonoBehaviour
{
    public GameObject Player;
    public Vector3 playerPos;
    public float force;
    public float range;

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
        playerPos = Player.transform.position;
        if(Vector3.Distance(playerPos, transform.position) <= range)
        {
            Player.transform.position =Vector3.MoveTowards(playerPos, transform.position, Time.deltaTime * force);
        }
    }
}
