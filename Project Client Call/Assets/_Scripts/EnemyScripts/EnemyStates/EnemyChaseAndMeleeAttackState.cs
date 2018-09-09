using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyChaseAndMeleeAttackState : AbstractState<EnemyFsmController>
{
    private EnemyMovement enemyMovement;
    private EnemyMeleeAttack meleeAttack;
    private EnemyData enemyData;
    [SerializeField]
    float speedInCharge = 100;
    float initialSpeed;
    public void Start()
    {
        meleeAttack = GetComponent<EnemyMeleeAttack>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyData = GetComponent<EnemyData>();
    }

    public void Update()
    {
        Vector2 distanceToPlayer= enemyData.Player.transform.position - transform.position;
        //IncreaseOfSpeed
        enemyMovement.Move(distanceToPlayer.normalized);
        //meleeAttack.MeleeAttack();
    }

    public override void Enter(IAgent pAgent)
    {
        Debug.Log("ENTER THE CHASE");
        base.Enter(pAgent);
        meleeAttack.MeleeAttack();
        initialSpeed = enemyData.MovementSpeed;
        enemyData.MovementSpeed = speedInCharge;
    }

    public override void Exit(IAgent pAgent)
    {
        GetComponent<EnemyPatrollingState>().ResetBorders();
        base.Exit(pAgent);
        enemyData.MovementSpeed = initialSpeed;
        meleeAttack.FinishMeleeAttack();
    }
}

