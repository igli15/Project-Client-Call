using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class EnemyOnKneeState : AbstractState<EnemyFsmController>
{

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        GetComponent<EnemyAnimations>().TrigerOnKneeAnimation();
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword Collider"))
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyDeadState>();
        }
    }
}
