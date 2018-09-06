using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyRangedAttackState : AbstractState<EnemyFsmController>
{

    private EnemyRangedAttack rangedAttack;
    private EnemyData enemyData;
    public void Start()
    {
        rangedAttack = GetComponent<EnemyRangedAttack>();
        enemyData = GetComponent<EnemyData>();
    }

    public void Update()
    {
        rangedAttack.ShootTo(enemyData.Player.transform.position);
    }
}

