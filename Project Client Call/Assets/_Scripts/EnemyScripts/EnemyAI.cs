using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyRangedAttack))]

public class EnemyAI : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    private Transform playerTransform;
    private EnemyMovement enemyMovement;
    private EnemyRangedAttack enemyRangedAttack;

    private void Start()
    {
        playerTransform = player.transform;
        enemyRangedAttack = GetComponent<EnemyRangedAttack>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    protected float GetHorizontalDirectionTo(Transform targetTransform)
    {
        float _horizontalDirection = targetTransform.position.x - transform.position.x;
        if (_horizontalDirection > 1) _horizontalDirection = 1;
        if (_horizontalDirection < -1) _horizontalDirection = -1;
        return _horizontalDirection;
    }
    protected void Follow(Transform targetTransform)
    {
        float _horizontalDirection=GetHorizontalDirectionTo(targetTransform);
        enemyMovement.Move(_horizontalDirection, 0);
    }

    protected void Avoid(Transform targetTransform)
    {
        float _horizontalDirection = GetHorizontalDirectionTo(targetTransform);
        enemyMovement.Move( -_horizontalDirection, 0); // negative direction
    }

    protected float DistanceToPlayer()
    {
        return (playerTransform.position.x - transform.position.x);
    }

}