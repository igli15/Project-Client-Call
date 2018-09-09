using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyData))]

public class EnemyMovement : MonoBehaviour
{

    private EnemyData enemyData;
    private Rigidbody2D rb;

    private Vector2 initForwardVec;
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyData = GetComponent<EnemyData>();

        initForwardVec = transform.right;
    }

    public void Move(float _horizontal,float _vertical)
    {
        Vector2 _movementVec = new Vector2(_horizontal, _vertical);
        _movementVec.Normalize();
        rb.velocity = _movementVec * enemyData.MovementSpeed * Time.fixedDeltaTime;
        CheckFlipHorizontally();
    }

    public void Move(Vector2 _movementVec)
    {
        _movementVec.Normalize();
        rb.velocity = _movementVec * enemyData.MovementSpeed * Time.fixedDeltaTime;
        CheckFlipHorizontally();
    }

    public void CheckFlipHorizontally()
    {
        if (rb.velocity.x < 0 && transform.right.Equals(initForwardVec))  //flip only if we haven't already flipped :P
        {
            transform.right = -transform.right;
        }
        else if (rb.velocity.x > 0 && !transform.right.Equals(initForwardVec))
        {
            transform.right = -transform.right;
        }
    }

}
