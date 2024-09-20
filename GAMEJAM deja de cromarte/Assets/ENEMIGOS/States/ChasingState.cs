using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : AEnemyState
{
    private Vector3 playerPos;
    private GameObject Player;

    public ChasingState(ROBdro enemy) : base(enemy)
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
        Vector2 or = new Vector2(enemy.GetGameObject().transform.position.x, enemy.GetGameObject().transform.position.y);
        Vector2 dt = new Vector2((playerPos - enemy.GetGameObject().transform.position).x, (playerPos - enemy.GetGameObject().transform.position).y);
        LayerMask mask = LayerMask.GetMask("SONAR");
        RaycastHit2D hit = Physics2D.Raycast(or, dt, Mathf.Infinity,~mask);
        if (hit.collider == null || hit.collider.tag != "Player")
        {
            enemy.SetState(new WaitingState(enemy));
        }

        else if (Vector3.Distance(playerPos, enemy.GetGameObject().transform.position) <= enemy.stats.range)
        {
            enemy.SetState(new AttackState(enemy));
        }
        else
        {
        enemy.MoveTowardsPlayer(playerPos);
        }
    }

    public override void FixedUpdate()
    {

    }
}
