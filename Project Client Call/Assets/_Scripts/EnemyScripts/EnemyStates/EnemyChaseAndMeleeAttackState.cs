using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMeleeAttack))]
public class EnemyChaseAndMeleeAttackState : AbstractState<EnemyFsmController>
{
    [Header("General")]
    [SerializeField]
    float speedInCharge = 100;
    [SerializeField]
    float distanceOfCharge = 3;
    [SerializeField]
    float distanceOfMelee = 1;
    [Header("Timing")]
    [SerializeField]
    float timeOfRecovering = 2;
    [SerializeField]
    float timeOfWaitingBeforeCharge = 1;

    float initialSpeed;

    EnemyFsmController fsmController;
    Vector3 endChargePosition;

    float timeOfEnterTostate;
    float stopTime;

    bool stoped;

    public void Start()
    {
        stoped = false;
        // endChargePosition = transform.position;
    }

    public void Update()
    {
        if (Time.time < timeOfEnterTostate + timeOfWaitingBeforeCharge) return;

        Vector2 distanceToEndPos = endChargePosition - transform.position;

        if (distanceToEndPos.magnitude < 0.2f || fsmController.stateReferences.enemyMovement.IsNextoToCliff())
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (stoped)
            {
                if (Time.time > stopTime + timeOfRecovering)
                {
                    fsmController.fsm.ChangeState<EnemyPatrollingState>();
                }
            }
            else
            {
                stoped = true;
                stopTime = Time.time;
                GetComponent<EnemyAnimations>().SetCharge(false);
                GetComponent<EnemyAnimations>().SetIdle(true);
            }
        }
        else
        {
            GetComponent<EnemyAnimations>().SetCharge(true);
            fsmController.stateReferences.enemyMovement.Move(distanceToEndPos.normalized.x, 0);
            CheckCollisionWithPlayer();
        }


    }

    public void CheckCollisionWithPlayer()
    {
        int layerMask = 1 << 10;
        Debug.DrawRay(transform.position, transform.right * distanceOfMelee);
        RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, transform.right, distanceOfMelee, layerMask);
        if (raycast2d.collider != null)
        {

            raycast2d.collider.GetComponentInParent<Health>().InflictDamage(1);
        }
    }

    public Vector3 CalculateDesiredPosition()
    {
        fsmController.stateReferences.enemyMovement.FaceToPlayer();
        return transform.position + transform.right * distanceOfCharge;
    }

    public override void Enter(IAgent pAgent)
    {
        stoped = false;
        timeOfEnterTostate = Time.time;
        if (!fsmController) fsmController = GetComponent<EnemyFsmController>();

        GetComponent<EnemyAnimations>().SetIdle(true);
        //CALCULATE <===========
        endChargePosition = CalculateDesiredPosition();
        base.Enter(pAgent);

        initialSpeed = fsmController.stateReferences.enemyData.MovementSpeed;
        fsmController.stateReferences.enemyData.MovementSpeed = speedInCharge;
    }

    public override void Exit(IAgent pAgent)
    {

        GetComponent<EnemyPatrollingState>().ResetBorders();
        GetComponent<EnemyAnimations>().SetCharge(false);
        GetComponent<EnemyAnimations>().SetIdle(false);
        base.Exit(pAgent);
        fsmController.stateReferences.enemyData.MovementSpeed = initialSpeed;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distanceOfMelee);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distanceOfCharge);
        Gizmos.color = Color.red;
        if (endChargePosition == null) return;
        Gizmos.DrawLine(transform.position, endChargePosition);
        Gizmos.DrawWireCube(endChargePosition, Vector3.one);
    }
}

