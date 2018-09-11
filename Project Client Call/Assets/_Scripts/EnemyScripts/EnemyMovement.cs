using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyData))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float offsetOfRaycasting=3;
    [SerializeField]
    float lengthOfRaycast = 3;
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

    public bool IsNextoToCliff()
    {
        int layerMask = (1 << 9);
        RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, -transform.up+transform.right*offsetOfRaycasting, lengthOfRaycast, layerMask);
        return raycast2d.collider == null;
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

    public void FaceToPlayer()
    {
        Vector2 distanceToPlayer = GetComponent<EnemyFsmController>().stateReferences.enemyData.Player.transform.position - transform.position;
        float direction = Mathf.Sign(distanceToPlayer.x);

        if (!transform.right.Equals(new Vector3(direction, 0)))
        {
            transform.right = new Vector3(direction, 0);
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position +(- transform.up + transform.right * offsetOfRaycasting)*lengthOfRaycast);
    }

}
