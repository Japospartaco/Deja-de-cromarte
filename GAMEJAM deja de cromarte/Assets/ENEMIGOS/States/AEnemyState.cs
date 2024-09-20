using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemyState : IState
{
    public ROBdro enemy;

    public AEnemyState(ROBdro enemy)
    {
        this.enemy = enemy;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void FixedUpdate();
}
