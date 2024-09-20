using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AEnemyState
{
    private Vector3 playerPos;
    private GameObject Player;
    private float timer;
    private bool isAttacking;

    public AttackState(ROBdro enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        Player = enemy.getPlayer();
        playerPos = Player.transform.position;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {
        playerPos = Player.transform.position;
        if (Vector3.Distance(playerPos, enemy.GetGameObject().transform.position) <= enemy.stats.range)
        {
            if (timer >= 0.5)
            {
                isAttacking = false;
                timer = 0;
            }
            if (!isAttacking)
            {
                isAttacking = true;
                enemy.Attack();
                timer = 0;

            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            enemy.SetState(new ChasingState(enemy));
        }
    }

    public override void FixedUpdate()
    {

    }
}
