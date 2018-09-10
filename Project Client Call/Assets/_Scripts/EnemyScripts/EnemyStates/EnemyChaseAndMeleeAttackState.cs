using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMeleeAttack))]
public class EnemyChaseAndMeleeAttackState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float speedInCharge = 100;
    float initialSpeed;

    EnemyFsmController fsmController;
    public void Start()
    {
        fsmController = GetComponent<EnemyFsmController>();
    }

    public void Update()
    {

        Vector2 distanceToPlayer = fsmController.stateReferences.enemyData.Player.transform.position - transform.position;
        //IncreaseOfSpeed
        fsmController.stateReferences.enemyMovement.Move(distanceToPlayer.normalized);
        //meleeAttack.MeleeAttack();
    }

    public override void Enter(IAgent pAgent)
    {
        Debug.Log("ENTER THE CHASE");

        base.Enter(pAgent);
        fsmController.stateReferences.enemyMeleeAttack.MeleeAttack();
        initialSpeed = fsmController.stateReferences.enemyData.MovementSpeed;
        fsmController.stateReferences.enemyData.MovementSpeed = speedInCharge;
    }

    public override void Exit(IAgent pAgent)
    {
        GetComponent<EnemyPatrollingState>().ResetBorders();
        base.Exit(pAgent);
        fsmController.stateReferences.enemyData.MovementSpeed = initialSpeed;
        fsmController.stateReferences.enemyMeleeAttack.FinishMeleeAttack();
    }
}

