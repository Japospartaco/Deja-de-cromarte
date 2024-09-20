using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolROBdro : IPool
{
    private IPooledObject robdro;

    public RobdroSpawner spawner;

    private List<IPooledObject> robdros;

    int listSize;

    public int activeRobdros;

    public PoolROBdro(IPooledObject robdro, int listSize, RobdroSpawner spawner)
    {
        this.robdro= robdro;
        this.listSize= listSize;
        this.spawner= spawner;
        robdros = new List<IPooledObject>(this.listSize);
        activeRobdros= 0;

        for(int i =0; i < listSize; i++)
        {
            this.robdros.Add(CreateRobdro(robdro));
        }
    }

    private IPooledObject CreateRobdro(IPooledObject robdro)
    {
        IPooledObject newRobdro = robdro.Clone();
        return newRobdro;
    }

    public IPooledObject Get()
    {
        for (int i = 0; i < robdros.Count; i++)
        {
            if (!robdros[i].Active)
            {
                robdros[i].Active = true;
                activeRobdros += 1;
                return robdros[i];
            }
        }
        return null;
    }

    public void Release(IPooledObject obj)
    {
        obj.Active = false;
        activeRobdros-= 1;
        obj.Reset();
    }

    public RobdroSpawner GetSpawner()
    {
        return spawner;
    }
}
