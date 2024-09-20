using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBdro : MonoBehaviour, IEnemy, IPooledObject
{
    public EnemyFlyWeight stats;
    public IPool pool;
    public int spawnPointId;
    public IState actualState;
    private GameObject Player;
    private int currentHp;


    public bool Active
    {
        get
        {
            return gameObject.activeSelf;
        }
        set
        {
            gameObject.SetActive(value);
        }
    }

    public IPooledObject Clone()
    {
        GameObject spawnedObj = Instantiate(gameObject);
        ROBdro clone = spawnedObj.GetComponent<ROBdro>();
        return clone;
    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
        this.pool.GetSpawner().spawnPoints[spawnPointId].z = 0;
        spawnPointId = -1;
        currentHp = stats.maxHp;
    }

    public void MoveTowardsPlayer(Vector3 playerPos)
    {
        //CAMBIO DE EJE SPRITE
        transform.position = Vector3.MoveTowards(transform.position, playerPos,
                    stats.speed * Time.deltaTime);
    }

    public void SetState(IState newState)
    {
        if (actualState != null)
        {
            actualState.Exit();
        }
        actualState = newState;
        actualState.Enter();
    }

    public GameObject getPlayer()
    {
        return Player;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }


    public void Attack()
    {
        Player.GetComponent<Timer>().UpdateTimerOnHit(stats.dmg);
    }


    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        SetState(new WaitingState(this));
        currentHp= stats.maxHp;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualState.Update();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "projectile")
        {
            Destroy(col.gameObject);
            currentHp -= 5;
            Debug.Log(currentHp);
            if (currentHp <= 0)
            {
                Player.GetComponent<Timer>().UpdateTimerOnHit(-10);
                this.pool.Release(this);
            }
        }
    }



}
