using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "GameItems/Characters/Enemy", order = 0)]
public class EnemyFlyWeight: ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int speed;
    public int dmg;
    public float attackSpeed;
    public float range;
}
