using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFsmController : MonoBehaviour, IAgent
{

    [HideInInspector]
    public Fsm<EnemyFsmController> fsm;
    private EnemyData enemyData;

    private float radiusOfShooting;

    void Start()
    {
        if (fsm == null)
        {
            fsm = new Fsm<EnemyFsmController>(this);
        }
        fsm.ChangeState<EnemyPatrollingState>();
        enemyData = GetComponent<EnemyData>();

        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
    }

    private void Update()
    {
        Vector2 distanceToPLayer = enemyData.Player.transform.position - transform.position;
        float _horizontalDirectionToPlayer = Mathf.Sign(distanceToPLayer.x);

        int layerMask = 1 << 10 | (1 << 9);
        RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, distanceToPLayer, radiusOfShooting, layerMask);

        bool isLooking = transform.right.x==_horizontalDirectionToPlayer;
        bool isInVision= raycast2d.collider != null && raycast2d.collider.CompareTag("Player");

        Debug.DrawRay(transform.position, distanceToPLayer);

        

        if ((distanceToPLayer).magnitude < radiusOfShooting && isLooking&& isInVision)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyRangedAttackState>();
        }
        else
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }

    }
}
