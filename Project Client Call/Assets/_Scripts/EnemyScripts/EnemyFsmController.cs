using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFsmController : MonoBehaviour, IAgent
{

    [HideInInspector]
    public Fsm<EnemyFsmController> fsm;

    void Start()
    {
        if (fsm == null)
        {
            fsm = new Fsm<EnemyFsmController>(this);
        }
        fsm.ChangeState<EnemyPatrollingState>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fsm.ChangeState<PlayerDeflectionState>();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //fsm.ChangeState<PlayerNormalState>();
        }
    }
}
