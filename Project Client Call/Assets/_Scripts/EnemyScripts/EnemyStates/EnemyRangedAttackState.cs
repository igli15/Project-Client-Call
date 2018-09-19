using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyRangedAttackState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float timeBeforeShoot = 1;
    enum localFsmState {Movement, Attack }
    localFsmState currentLocalFsmState;

    private EnemyRangedAttack rangedAttack;
    private EnemyFsmController fsmController;
    private EnemyAnimations animations;
    float timePassed;
    public void Start()
    {
        
    }

    public void Update()
    {
        if (currentLocalFsmState == localFsmState.Movement)
        {
            timePassed += Time.deltaTime;
            fsmController.stateReferences.enemyMovement.Move(transform.right);
            if (timeBeforeShoot > timePassed  || (fsmController.stateReferences.enemyData.Player.transform.position - transform.position).magnitude < 1)
            {
                currentLocalFsmState = localFsmState.Attack;
            }
        }

        if (currentLocalFsmState == localFsmState.Attack)
        {
            fsmController.stateReferences.enemyMovement.FaceToPlayer();
            ShootToPlayer();
        }
    }

    public override void Enter(IAgent pAgent)
    {
        if(!animations) animations = GetComponent<EnemyAnimations>();
        if (!fsmController) fsmController = GetComponent<EnemyFsmController>();
        fsmController.stateReferences.enemyRangedAttack.SeetReloadZero();
        currentLocalFsmState = localFsmState.Movement;
        timePassed = 0;

        fsmController.stateReferences.enemyRangedAttack.ResetReloadTime();


        animations.SetAttackState(true);
        base.Enter(pAgent);
        fsmController.stateReferences.enemyMovement.FaceToPlayer();
    }

    public override void Exit(IAgent pAgent)
    {
        fsmController.stateReferences.enemyRangedAttack.ResetReloadTime();
        animations.SetAttackState(false);
        base.Exit(pAgent);
    }

    void ShootToPlayer()
    {
        if(fsmController.isInVision)
            fsmController.stateReferences.enemyRangedAttack.ShootTo(fsmController.stateReferences.enemyData.Player.transform.position);
    }
}

