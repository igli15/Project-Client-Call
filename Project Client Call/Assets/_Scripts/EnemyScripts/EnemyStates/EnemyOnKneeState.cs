using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class EnemyOnKneeState : AbstractState<EnemyFsmController>
{

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        GetComponent<EnemyAnimations>().TrigerDeathAnimation();

    }

    void Update () {
		
	}
}
