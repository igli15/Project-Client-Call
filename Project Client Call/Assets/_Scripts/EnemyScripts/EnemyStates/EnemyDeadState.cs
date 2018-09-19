using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class EnemyDeadState : AbstractState<EnemyFsmController>
{
    EnemyAnimations animations;
    public void Start()
    {
        
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        if(!animations) animations = GetComponent<EnemyAnimations>();
        animations.TrigerDeathAnimation();

    }

}

