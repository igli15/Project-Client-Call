using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFsmController : MonoBehaviour, IAgent
{
    enum EnemyType {Simple,Tank,Striker, Cannoneer }
    [SerializeField]
    EnemyType enemyType;

    [HideInInspector]
    public Fsm<EnemyFsmController> fsm;
    private EnemyData enemyData;

    private float radiusOfShooting;
    private float radiusOfMeleeeAttack;
    Vector2 distanceToPLayer
    {
        get { return enemyData.Player.transform.position - transform.position; }
    }
    bool isLooking
    {
        get { return transform.right.x == Mathf.Sign(distanceToPLayer.x); }
    }
    bool isInVision
    {
        get {
            int layerMask = 1 << 10 | (1 << 9);
            RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, distanceToPLayer, distanceToPLayer.magnitude, layerMask);
            return raycast2d.collider != null && raycast2d.collider.CompareTag("Player");
            }
    }

    void Start()
    {
        if (fsm == null)
        {
            fsm = new Fsm<EnemyFsmController>(this);
        }
        fsm.ChangeState<EnemyPatrollingState>();
        enemyData = GetComponent<EnemyData>();

        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
        radiusOfMeleeeAttack= GetComponent<EnemyPatrollingState>().RadiusOfMelleAttack;
    }

    private void Update()
    {
        switch (enemyType)
        {
            case EnemyType.Simple:
                CheckConditionsForSimpleEnemy();
                break;
            case EnemyType.Tank:
                CheckConditionsForTankEnemy();
                break;
        }
        
    }
    void CheckConditionsForTankEnemy()
    {
        Debug.Log("TANK: 0+"+ isLooking+" | "+isInVision);
        if ((distanceToPLayer).magnitude < radiusOfMeleeeAttack && isLooking && isInVision)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyChaseAndMeleeAttackState>();
        }
        else
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }
    }


    void CheckConditionsForSimpleEnemy()
    {
        if ((distanceToPLayer).magnitude < radiusOfMeleeeAttack && isLooking && isInVision)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyMeleeAttackState>();
        }
        else if ((distanceToPLayer).magnitude < radiusOfShooting && isLooking && isInVision)
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyRangedAttackState>();
        }
        else
        {
            GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyPatrollingState>();
        }
    }
}
