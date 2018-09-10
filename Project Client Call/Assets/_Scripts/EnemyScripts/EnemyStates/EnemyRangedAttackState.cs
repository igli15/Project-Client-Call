using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyRangedAttackState : AbstractState<EnemyFsmController>
{


    private EnemyRangedAttack rangedAttack;
    private EnemyFsmController fsmCOntroller;

    float radiusOfShooting;
    public void Start()
    {
        rangedAttack = GetComponent<EnemyRangedAttack>();
        fsmCOntroller = GetComponent<EnemyFsmController>();

        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
    }

    public void Update()
    {
        rangedAttack.ShootTo(fsmCOntroller.stateReferences.enemyData.Player.transform.position);
        CheckStateConditions();
    }


    void CheckStateConditions()
    {
        if ((fsmCOntroller.stateReferences.enemyData.Player.transform.position - transform.position).magnitude > radiusOfShooting)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }
    }
}

