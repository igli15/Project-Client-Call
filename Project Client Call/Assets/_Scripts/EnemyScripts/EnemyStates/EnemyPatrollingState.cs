﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : AbstractState<EnemyFsmController>
{
    
    [SerializeField]
    float radiusOfPatrolling = 5;
    [Header("Red Sphere")]
    [SerializeField]
    float radiusOfRangedAttack = 5;
    [Header("Purple Sphere")]
    [SerializeField]
    float radiusOfMeleeAttack = 1;
    [Header("Green Sphere")]
    [SerializeField]
    float radiusOfFootStepHearing = 2;

    float currentDirection;
    float distanceToStop = 0.2f;

    EnemyFsmController fsmController;

    Rigidbody2D rb;
    Vector3 destination1;
    Vector3 destination2;

    bool running = false;

    public float RadiusOfRangedAttack { get { return radiusOfRangedAttack; } }
    public float RadiusOfMelleAttack { get { return radiusOfMeleeAttack; } }
    public float RadiusOfFootStepsHearing { get { return radiusOfFootStepHearing; } }

    void Start()
    {
        running = true;
        currentDirection = 1;
        fsmController = GetComponent<EnemyFsmController>();
        rb = GetComponent<Rigidbody2D>();

        ResetBorders();
    }

    public void ResetBorders()
    {
        int layerMask = (1 << 9);
        
        RaycastHit2D raycast2d = Physics2D.Raycast(transform.position,new Vector2(-1,0), radiusOfPatrolling, layerMask);
        if (raycast2d.collider != null)
        {
            destination1 = (transform.position - new Vector3(raycast2d.distance-0.5f, 0, 0));
        }
        else destination1 = (transform.position - new Vector3(radiusOfPatrolling, 0, 0));

        raycast2d = Physics2D.Raycast(transform.position, new Vector2(1,0), radiusOfPatrolling, layerMask);
        if (raycast2d.collider != null)
        {
            destination2 = (transform.position + new Vector3(raycast2d.distance -0.5f, 0, 0));
        }
        else destination2 = (transform.position + new Vector3(radiusOfPatrolling, 0, 0));
    }

    public void Update()
    {
        Patroll();
    }



    public void Patroll()
    {
        if (fsmController.stateReferences.enemyMovement.IsNextoToCliff()) currentDirection*=-1;

        else if (transform.position.x - destination1.x < distanceToStop) currentDirection = 1;

        else if (destination2.x - transform.position.x < distanceToStop) currentDirection = -1;


        fsmController.stateReferences.enemyMovement.Move(currentDirection, 0);
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
    }

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
       rb.velocity = Vector2.zero;
    }

    public void OnDrawGizmosSelected()
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusOfFootStepHearing);
    }
}
