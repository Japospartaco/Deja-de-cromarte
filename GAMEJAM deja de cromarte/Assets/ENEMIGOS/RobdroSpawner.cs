using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class RobdroSpawner : MonoBehaviour
{
    public GameObject robdroGO;
    public int nEnemies;
    public float enemiesPerSpawn;
    public float spawnRate;

    private float clock = 0;

    private PoolROBdro poolRobdros;

    public Vector3[] spawnPoints;

    void Awake()
    {
        IPooledObject robdroComp = robdroGO.GetComponent<IPooledObject>();

        poolRobdros = new PoolROBdro(robdroComp, nEnemies, this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        clock += Time.deltaTime;
        if (clock >= spawnRate)
        {

            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (poolRobdros.activeRobdros < nEnemies)
                {
                    ROBdro robdro = CreateRobdro();
                }

            }
            clock = 0;
        }
    }

    private ROBdro CreateRobdro()
    {
        int random = (int)(Random.value * 100) % spawnPoints.Length;
        if (spawnPoints[random].z == 0)
        {
            ROBdro newRobdro = (ROBdro)poolRobdros.Get();
            newRobdro.spawnPointId = random;
            newRobdro.pool = poolRobdros;
            float x = spawnPoints[random].x;
            float y = spawnPoints[random].y;
            newRobdro.transform.position = new Vector3(x, y, 0);
            spawnPoints[random].z = 1;
            return newRobdro;
        }
        else
        {
            return null;
        }
    }
}
