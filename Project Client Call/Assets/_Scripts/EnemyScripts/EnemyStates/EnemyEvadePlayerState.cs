using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvadePlayerState : AbstractState<EnemyFsmController>
{
    [SerializeField]
    float speedInChargeBack = 100;
    [SerializeField]
    float distanceOfChargeBack = 10;

    EnemyFsmController fsmController;

    private float initialSpeed;
    private Vector2 destination;
    float direction;
    public void Start()
    {

    }

    public void Update()
    {
        if (Mathf.Abs(destination.x-transform.position.x ) >= 2)
        {

           fsmController.stateReferences.enemyMovement.Move(direction, 0);
           
        }
        else { fsmController.fsm.ChangeState<EnemyPatrollingState>(); }
    }

    public override void Enter(IAgent pAgent)
    {
        if (!fsmController) fsmController = GetComponent<EnemyFsmController>();
        base.Enter(pAgent);


        Vector2 distanceToPlayer = fsmController.stateReferences.enemyData.Player.transform.position - transform.position;
        direction = -Mathf.Sign(distanceToPlayer.x);

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

        initialSpeed = fsmController.stateReferences.enemyData.MovementSpeed;
        fsmController.stateReferences.enemyData.MovementSpeed = speedInChargeBack;
    }

    public override void Exit(IAgent pAgent)
    {

        base.Exit(pAgent);
        fsmController.stateReferences.enemyData.MovementSpeed = initialSpeed;
        //GetComponent<EnemyPatrollingState>().ResetBorders();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(destination, 1);
    }
}

