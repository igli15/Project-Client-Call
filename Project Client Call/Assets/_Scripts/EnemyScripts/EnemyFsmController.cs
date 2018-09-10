using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFsmController : MonoBehaviour, IAgent
{
    enum EnemyType { Simple, Tank, Striker, Cannoneer }
    [SerializeField]
    EnemyType enemyType;
    [HideInInspector]
    public Fsm<EnemyFsmController> fsm;
    [HideInInspector]
    public StateReferences stateReferences;

    private float radiusOfShooting;
    private float radiusOfMeleeeAttack;

    Vector2 distanceToPLayer
    {
        get { return stateReferences.enemyData.Player.transform.position - transform.position; }
    }
    bool isLooking
    {
        get { return transform.right.x == Mathf.Sign(distanceToPLayer.x); }
    }
    bool isInVision
    {
        get
        {
            int layerMask = 1 << 10 | (1 << 9);
            RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, distanceToPLayer, distanceToPLayer.magnitude, layerMask);
            return raycast2d.collider != null && raycast2d.collider.CompareTag("Player");
        }
    }
    bool areComponentsReady;

    void Start()
    {
        if (fsm == null)
        {
            fsm = new Fsm<EnemyFsmController>(this);
        }
        areComponentsReady = false;


        fsm.ChangeState<EnemyPatrollingState>();


        radiusOfShooting = GetComponent<EnemyPatrollingState>().RadiusOfRangedAttack;
        radiusOfMeleeeAttack = GetComponent<EnemyPatrollingState>().RadiusOfMelleAttack;
    }

    private void Update()
    {
        if (!areComponentsReady)
        {
            stateReferences = new StateReferences(GetComponent<EnemyData>(), GetComponent<EnemyMovement>(),
                                                  GetComponent<EnemyMeleeAttack>(), GetComponent<EnemyRangedAttack>());
            areComponentsReady = true;
        }
        switch (enemyType)
        {
            case EnemyType.Simple:
                CheckConditionsForSimpleEnemy();
                break;
            case EnemyType.Tank:
                CheckConditionsForTankEnemy();
                break;
            case EnemyType.Striker:
                CheckConditionsForStrikerEnemy();
                break;
        }

    }
    void CheckConditionsForStrikerEnemy()
    {

    }

    void CheckConditionsForTankEnemy()
    {
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

public struct StateReferences
{
    public EnemyData enemyData;
    public EnemyMovement enemyMovement;
    public EnemyMeleeAttack enemyMeleeAttack;
    public EnemyRangedAttack enemyRangedAttack;

    public StateReferences(EnemyData enemyData, EnemyMovement enemyMovement,
        EnemyMeleeAttack enemyMeleeAttack, EnemyRangedAttack enemyRangedAttack)
    {
        Debug.Log("StateReferences is ready");
        this.enemyData = enemyData;
        this.enemyMovement = enemyMovement;
        this.enemyMeleeAttack = enemyMeleeAttack;
        Debug.Log("MeleeAttack: " + enemyMeleeAttack);
        this.enemyRangedAttack = enemyRangedAttack;
    }
}
