using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]

public class EnemyAI : MonoBehaviour
{
    [SerializeField] 
    private Transform playerTransform;
    
    private EnemyMovement enemyMovement;
    private EnemyRangedAttack enemyRangedAttack;
    void Start()
    {
        enemyRangedAttack = GetComponent<EnemyRangedAttack>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        enemyRangedAttack.ShootTo(playerTransform.position);
        //Avoid(playerTransform);
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