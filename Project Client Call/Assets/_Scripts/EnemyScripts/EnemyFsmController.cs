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

        if ((enemyData.Player.transform.position - transform.position).magnitude < radiusOfShooting)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyRangedAttackState>();
        }
        else
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }

    }
}
