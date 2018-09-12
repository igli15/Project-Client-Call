using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyRangedAttackState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float movementSpeedInAttack = 50;
    [SerializeField]
    float timeBeforeShoot = 1;
    enum localFsmState {Movement, Attack }
    localFsmState currentLocalFsmState;

    private EnemyRangedAttack rangedAttack;
    private EnemyFsmController fsmController;

    float radiusOfShooting;
    float timeMovementStarted;
    public void Start()
    {
        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
    }

    public void Update()
    {
        if (currentLocalFsmState == localFsmState.Movement)
        {
            fsmController.stateReferences.enemyMovement.Move(transform.right);
            if (Time.time > timeMovementStarted + timeBeforeShoot || (fsmController.stateReferences.enemyData.Player.transform.position - transform.position).magnitude < 1)
            {
                currentLocalFsmState = localFsmState.Attack;
            }
        }

        if (currentLocalFsmState == localFsmState.Attack)
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fsmController.stateReferences.enemyMovement.FaceToPlayer();
            ShootToPlayer();
        }
    }

    public override void Enter(IAgent pAgent)
    {
        if (!fsmController) fsmController = GetComponent<EnemyFsmController>();
        GetComponent<EnemyRangedAttack>().SeetReloadZero();
        currentLocalFsmState = localFsmState.Movement;
        timeMovementStarted = Time.time;
        GetComponent<EnemyAnimations>().SetAttackState(true);
        base.Enter(pAgent);
        fsmController.stateReferences.enemyMovement.FaceToPlayer();
    }

    public override void Exit(IAgent pAgent)
    {
        GetComponent<EnemyRangedAttack>().ResetReloadTime();
        GetComponent<EnemyAnimations>().SetAttackState(false);
        base.Exit(pAgent);
    }

    void ShootToPlayer()
    {
        if(fsmController.isInVision)
            fsmController.stateReferences.enemyRangedAttack.ShootTo(fsmController.stateReferences.enemyData.Player.transform.position);
    }
}

