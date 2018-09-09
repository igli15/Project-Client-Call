using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyMeleeAttackState : AbstractState<EnemyFsmController>
{

    private EnemyMeleeAttack meleeAttack;
    private EnemyData enemyData;
    public void Start()
    {
        meleeAttack = GetComponent<EnemyMeleeAttack>();
        enemyData = GetComponent<EnemyData>();
    }

    public void Update()
    {
        
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        meleeAttack.MeleeAttack();
    }

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
        meleeAttack.FinishMeleeAttack();
    }
}

