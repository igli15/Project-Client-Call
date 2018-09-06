using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float radiusOfPatrolling = 5;

    float currentDirection;
    float distanceToStop = 0.2f;
    EnemyMovement enemyMovement;

    Vector3 destination1;
    Vector3 destination2;

    void Start()
    {
        currentDirection = 1;
        enemyMovement = GetComponent<EnemyMovement>();
        destination1= (transform.position - new Vector3(radiusOfPatrolling, 0, 0));
        destination2= (transform.position + new Vector3(radiusOfPatrolling, 0, 0));
    }

    public void Update()
    {
        Patroll();
    }

    public void Patroll()
    {
        if( ( transform.position.x - destination1.x < distanceToStop) || (destination2.x - transform.position.x < distanceToStop)) currentDirection *= -1;

        enemyMovement.Move(currentDirection, 0);
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, destination1);
        Gizmos.DrawLine(transform.position, destination2);

        Gizmos.DrawWireCube(destination1, new Vector3(0.2f,1,0.2f));
        Gizmos.DrawWireCube(destination2, new Vector3(0.2f,1,0.2f));
    }
}
