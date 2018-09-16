using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class EnemyDeadState : AbstractState<EnemyFsmController>
{
    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        GetComponent<EnemyAnimations>().TrigerDeathAnimation();
        Debug.Log("FINAL DEATH");
       // GetComponent<EnemyMovement>().FaceToPlayer();
        //transform.right = -transform.right;
    }
}

