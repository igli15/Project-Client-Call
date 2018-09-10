using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRangedAttack))]
public class EnemyEvadeState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float speedInChargeBack = 100;
    [SerializeField]
    float distanceOfChargeBack = 10;

    private EnemyMovement enemyMovement;
    private EnemyData enemyData;

    private float initialSpeed;
    private Vector2 destination;
    float direction;
    public void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyData = GetComponent<EnemyData>();
    }

    public void Update()
    {
        if ((transform.position.x - destination.x) >= 1)
        {
            enemyMovement.Move(direction, 0);
        }
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        Vector2 distanceToPlayer = enemyData.Player.transform.position - transform.position;
        direction = Mathf.Sign(distanceToPlayer.x);

        int layerMask = (1 << 9);
        RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, transform.right * direction, distanceOfChargeBack, layerMask);
        if (raycast2d.collider != null)
        {
            destination = raycast2d.point;
        }
        else
        {
            destination = transform.position + transform.right * direction * distanceOfChargeBack;
        }

        initialSpeed = enemyData.MovementSpeed;
        enemyData.MovementSpeed = speedInChargeBack;
    }

    public override void Exit(IAgent pAgent)
    {

        base.Exit(pAgent);
        enemyData.MovementSpeed = initialSpeed;
        GetComponent<EnemyPatrollingState>().ResetBorders();
    }
}

