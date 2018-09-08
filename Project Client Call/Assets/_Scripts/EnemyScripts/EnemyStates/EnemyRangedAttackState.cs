using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyRangedAttackState : AbstractState<EnemyFsmController>
{
    

    private EnemyRangedAttack rangedAttack;
    private EnemyData enemyData;

    float radiusOfShooting;
    public void Start()
    {
        rangedAttack = GetComponent<EnemyRangedAttack>();
        enemyData = GetComponent<EnemyData>();

        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
    }

    public void Update()
    {
        rangedAttack.ShootTo(enemyData.Player.transform.position);
        CheckStateConditions();
    }


    void CheckStateConditions()
    {
        if ((enemyData.Player.transform.position - transform.position).magnitude > radiusOfShooting)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }
    }
}

