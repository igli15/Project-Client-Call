using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class EnemyDeadState : AbstractState<EnemyFsmController>
{
    EnemyAnimations animations;
    public void Start()
    {
        animations = GetComponent<EnemyAnimations>();
        Debug.Log("START COROUTINE");
        StartCoroutine(DOEST());
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        animations.TrigerDeathAnimation();

    }

    IEnumerator DOEST()
    {
        Debug.Log("START: " + Time.time);
        yield return new WaitForSeconds(.1f);
        Debug.Log("FINISH: " + Time.time);
    }
}

