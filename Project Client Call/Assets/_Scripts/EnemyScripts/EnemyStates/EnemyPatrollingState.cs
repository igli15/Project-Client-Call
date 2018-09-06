using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float radiusOfPatrolling = 5;
    [SerializeField]
    float radiusOfPlayerIdentification = 5;

    float currentDirection;
    float distanceToStop = 0.2f;

    EnemyMovement enemyMovement;
    EnemyData enemyData;

    Vector3 destination1;
    Vector3 destination2;

    bool running=false;
    void Start()
    {
        running = true;
        currentDirection = 1;
        enemyMovement = GetComponent<EnemyMovement>();
        enemyData = GetComponent<EnemyData>();

        destination1 = (transform.position - new Vector3(radiusOfPatrolling, 0, 0));
        destination2 = (transform.position + new Vector3(radiusOfPatrolling, 0, 0));
    }

    public void Update()
    {
        Patroll();
        if ((enemyData.Player.transform.position - transform.position).magnitude < radiusOfPlayerIdentification)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyRangedAttackState>();
        }
    }

    public void Patroll()
    {
        if(transform.position.x - destination1.x < distanceToStop) currentDirection = 1;

        if(destination2.x - transform.position.x < distanceToStop)  currentDirection = -1;


        enemyMovement.Move(currentDirection, 0);
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
            destination1 = (transform.position - new Vector3(radiusOfPatrolling, 0, 0));
            destination2 = (transform.position + new Vector3(radiusOfPatrolling, 0, 0));
        }

        Gizmos.DrawLine(transform.position, destination1);
        Gizmos.DrawLine(transform.position, destination2);

        Gizmos.DrawWireCube(destination1, new Vector3(0.2f,1,0.2f));
        Gizmos.DrawWireCube(destination2, new Vector3(0.2f,1,0.2f));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfPlayerIdentification);
    }
}
