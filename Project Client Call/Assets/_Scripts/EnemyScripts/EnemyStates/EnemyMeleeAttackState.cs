using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyMeleeAttackState : AbstractState<EnemyFsmController>
{
    private EnemyFsmController fsmController;
    public void Start()
    {
    }

    public void Update()
    {

    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        if (!fsmController) fsmController = GetComponent<EnemyFsmController>();
        fsmController.stateReferences.enemyMeleeAttack.MeleeAttack();
    }

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
        fsmController.stateReferences.enemyMeleeAttack.FinishMeleeAttack();
    }
}

