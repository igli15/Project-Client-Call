using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class EnemyOnKneeState : AbstractState<EnemyFsmController>
{
    bool isActivated;
    EnemyAnimations enemyAnimations;
    Rigidbody2D rb;
    BoxCollider2D collider;
    EnemyFsmController fsmController;

    public void Start()
    {

    }
    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        enemyAnimations.TrigerOnKneeAnimation();
        rb.velocity = Vector3.zero;
        collider.isTrigger = true;
        rb.isKinematic = true;
        collider.offset -= new Vector2(-4, 0);
    }

    public void SetEverything()
    {
        enemyAnimations = GetComponent<EnemyAnimations>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        fsmController = GetComponent<EnemyFsmController>();

        isActivated = false;
    }


    void Update()
    {
    }

    public void FinishHim()
    {
        if (isActivated) return;
        HighScoreManager.instance.InreaseKillScore();
        HighScoreManager.instance.DecreaseSocializerScore();
        enemyAnimations.SetDeathState(true);
        fsmController.fsm.ChangeState<EnemyDeadState>();
        isActivated = true;
    }

}
