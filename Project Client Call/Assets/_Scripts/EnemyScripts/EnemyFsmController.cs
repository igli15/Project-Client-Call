using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFsmController : MonoBehaviour, IAgent
{

    [HideInInspector]
    public Fsm<EnemyFsmController> fsm;
    private EnemyData enemyData;

    void Start()
    {
        if (fsm == null)
        {
            fsm = new Fsm<EnemyFsmController>(this);
        }
        fsm.ChangeState<EnemyPatrollingState>();
        enemyData = GetComponent<EnemyData>();
    }

    private void Update()
    {
        
    }
}
