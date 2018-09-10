using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyRangedAttackState : AbstractState<EnemyFsmController>
{


    private EnemyRangedAttack rangedAttack;
    private EnemyFsmController fsmController;

    float radiusOfShooting;
    public void Start()
    {


        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
    }

    public void Update()
    {
        fsmController.stateReferences.enemyRangedAttack.ShootTo(fsmController.stateReferences.enemyData.Player.transform.position);
        CheckStateConditions();
    }

    public override void Enter(IAgent pAgent)
    {
        if(!fsmController) fsmController = GetComponent<EnemyFsmController>();
        base.Enter(pAgent);
        fsmController.stateReferences.enemyMovement.FaceToPlayer();
    }


    void CheckStateConditions()
    {
        if ((fsmController.stateReferences.enemyData.Player.transform.position - transform.position).magnitude > radiusOfShooting)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }
    }
}

