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
        ShootToPlayer();
    }

    public override void Enter(IAgent pAgent)
    {
        if(!fsmController) fsmController = GetComponent<EnemyFsmController>();
        base.Enter(pAgent);
        fsmController.stateReferences.enemyMovement.FaceToPlayer();
    }

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
        GetComponent<EnemyRangedAttack>().ResetReloadTime();
    }

    void ShootToPlayer()
    {
        if(fsmController.isInVision)
        fsmController.stateReferences.enemyRangedAttack.ShootTo(fsmController.stateReferences.enemyData.Player.transform.position);
    }
}

