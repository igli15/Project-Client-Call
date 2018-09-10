using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyMeleeAttackState : AbstractState<EnemyFsmController>
{
    private EnemyFsmController fsmController;
    public void Start()
    {
        fsmController = GetComponent<EnemyFsmController>();
    }

    public void Update()
    {

    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        Debug.Log("Enter of MeleeAttackSTate");
        if (null == fsmController) Debug.Log("SUKA BLYAT");
        fsmController.stateReferences.enemyMeleeAttack.MeleeAttack();
    }

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
        fsmController.stateReferences.enemyMeleeAttack.FinishMeleeAttack();
    }
}

