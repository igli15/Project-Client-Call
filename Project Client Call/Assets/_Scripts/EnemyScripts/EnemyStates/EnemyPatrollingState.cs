using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float radiusOfPatrolling = 5;
    [SerializeField]
    float radiusOfRangedAttack = 5;
    [SerializeField]
    float radiusOfMeleeAttack = 1;

    float currentDirection;
    float distanceToStop = 0.2f;

    EnemyFsmController fsmController;

    Vector3 destination1;
    Vector3 destination2;

    bool running = false;

    public float RadiusOfRangedAttack { get { return radiusOfRangedAttack; } }
    public float RadiusOfMelleAttack { get { return radiusOfMeleeAttack; } }

    void Start()
    {
        running = true;
        currentDirection = 1;
        fsmController = GetComponent<EnemyFsmController>();

        ResetBorders();
    }

    public void ResetBorders()
    {
        destination1 = (transform.position - new Vector3(radiusOfPatrolling, 0, 0));
        destination2 = (transform.position + new Vector3(radiusOfPatrolling, 0, 0));
    }

    public void Update()
    {
        Patroll();
    }



    public void Patroll()
    {
        if (transform.position.x - destination1.x < distanceToStop) currentDirection = 1;

        if (destination2.x - transform.position.x < distanceToStop) currentDirection = -1;


        fsmController.stateReferences.enemyMovement.Move(currentDirection, 0);
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
    }

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (!running)
        {
            ResetBorders();
        }

        Gizmos.DrawLine(transform.position, destination1);
        Gizmos.DrawLine(transform.position, destination2);

        Gizmos.DrawWireCube(destination1, new Vector3(0.2f, 1, 0.2f));
        Gizmos.DrawWireCube(destination2, new Vector3(0.2f, 1, 0.2f));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfRangedAttack);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radiusOfMeleeAttack);
    }
}
