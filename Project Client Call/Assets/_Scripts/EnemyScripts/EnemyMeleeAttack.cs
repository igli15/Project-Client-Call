using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]

public class EnemyMeleeeAttack : MonoBehaviour
{
    [SerializeField]
    GameObject damageBox;

    EnemyMovement enemyMovement;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        damageBox.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void MeleeAttack(float direction)
    {
        if (direction > 1) direction = 1;
        if (direction < -1) direction = -1;
        enemyMovement.Move(direction, 0);
        damageBox.GetComponent<BoxCollider2D>().enabled = true;
    }

}

