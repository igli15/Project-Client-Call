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

    private void FixedUpdate()
    {
        enemyRangedAttack.ShootTo(playerTransform.position);
        //Follow(playerTransform);
    }

    private float GetHorizontalDirectionTo(Transform targetTransform)
    {
        float _horizontalDirection = targetTransform.position.x - transform.position.x;
        if (_horizontalDirection > 1) _horizontalDirection = 1;
        if (_horizontalDirection < -1) _horizontalDirection = -1;
        return _horizontalDirection;
    }
    private void Follow(Transform targetTransform)
    {
        float _horizontalDirection=GetHorizontalDirectionTo(targetTransform);
        enemyMovement.Move(_horizontalDirection, 0);
    }

    private void Avoid(Transform targetTransform)
    {
        float _horizontalDirection = GetHorizontalDirectionTo(targetTransform);
        enemyMovement.Move( -_horizontalDirection, 0); // negative direction
    }

}