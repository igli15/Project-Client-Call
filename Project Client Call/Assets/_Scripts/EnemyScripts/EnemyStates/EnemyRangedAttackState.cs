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
    float timeMovementStarted;
    public void Start()
    {
        
    }

    public void Update()
    {
        if (currentLocalFsmState == localFsmState.Movement)
        {
            fsmController.stateReferences.enemyMovement.Move(transform.right);
            if (Time.time > timeMovementStarted + timeBeforeShoot || (fsmController.stateReferences.enemyData.Player.transform.position - transform.position).magnitude < 1)
            {
                Debug.Log("LOCAL_FSM ==> SWITCH TO ATTACK STATE");
                currentLocalFsmState = localFsmState.Attack;
            }
        }

        if (currentLocalFsmState == localFsmState.Attack)
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("LOCAL_FSM ==> START ATTACK STATE");
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
        timeMovementStarted = Time.time;

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

