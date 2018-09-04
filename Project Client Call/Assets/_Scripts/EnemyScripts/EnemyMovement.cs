using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyData))]

public class EnemyMovement : MonoBehaviour
{

    private EnemyData enemyData;
    private Rigidbody2D rb;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyData = GetComponent<EnemyData>();
    }

    public void Move(float _horizontal,float _vertical)
    {
        Vector2 _movementVec = new Vector2(_horizontal, _vertical); 

        rb.velocity = _movementVec * enemyData.MovementSpeed() * Time.fixedDeltaTime;
    }




}
