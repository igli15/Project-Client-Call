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
    private float radiusOfFootStepsHearing;
    private bool isDead;

    Vector2 distanceToPLayer
    {
        get { return stateReferences.enemyData.Player.transform.position - transform.position; }
    }

    public bool isLooking
    {
        get { return transform.right.x == Mathf.Sign(distanceToPLayer.x); }
    }
    public bool isInVision
    {
        get
        {
            int layerMask = 1 << 10 | (1 << 9);
            Debug.DrawRay(transform.position, distanceToPLayer);
            RaycastHit2D raycast2d = Physics2D.Raycast(transform.position, distanceToPLayer, distanceToPLayer.magnitude, layerMask);
            return raycast2d.collider != null && ( raycast2d.collider.transform.CompareTag("Player") || raycast2d.collider.transform.CompareTag("Sword Collider"));
        }
    }
    bool canBeHeared
    {
        get {
            return (stateReferences.enemyData.Player.transform.position - transform.position).magnitude < radiusOfFootStepsHearing;
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
        isDead = false;
        fsm.ChangeState<EnemyPatrollingState>();
        GetComponent<Health>().OnDeath += OnDeath;
        radiusOfFootStepsHearing = GetComponent<EnemyPatrollingState>().RadiusOfFootStepsHearing;
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

        if (isDead) return;

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
            case EnemyType.Cannoneer:
                CheckConditionsForCannoneerEnemy();
                break;
        }

    }

    void OnDeath(Health health)
    {
        isDead = true;
        fsm.ChangeState<EnemyOnKneeState>();
    }

    void CheckConditionsForCannoneerEnemy()
    {
        if ((distanceToPLayer).magnitude < radiusOfShooting && (isLooking && isInVision || canBeHeared))
        {
            fsm.ChangeState<EnemyRangedAttackState>();
        }
        else
        {
            fsm.ChangeState<EnemyPatrollingState>();
        }
    }

    void CheckConditionsForStrikerEnemy()
    {
        if (Input.GetKeyDown(KeyCode.L) || fsm.GetCurrentState() is EnemyEvadePlayerState)
        {
            Debug.Log("Striker GoingBack");
            fsm.ChangeState<EnemyEvadePlayerState>();
        }
        else if ((distanceToPLayer).magnitude < radiusOfMeleeeAttack && ( isLooking && isInVision || canBeHeared))
        {
            Debug.Log("STRIKER CHASES");
            fsm.ChangeState<EnemyChaseAndMeleeAttackState>();
        }
        else
        {
            fsm.ChangeState<EnemyPatrollingState>();
        }
    }

    void CheckConditionsForTankEnemy()
    {
        if ((distanceToPLayer).magnitude < radiusOfMeleeeAttack && (isLooking && isInVision || canBeHeared))
        {
            fsm.ChangeState<EnemyChaseAndMeleeAttackState>();
        }
    }


    void CheckConditionsForSimpleEnemy()
    {
        if ((distanceToPLayer).magnitude < radiusOfShooting && (isLooking && isInVision || canBeHeared))
        {
           fsm.ChangeState<EnemyRangedAttackState>();
        }
        else
        {
            fsm.ChangeState<EnemyPatrollingState>();
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
        this.enemyData = enemyData;
        this.enemyMovement = enemyMovement;
        this.enemyMeleeAttack = enemyMeleeAttack;
        this.enemyRangedAttack = enemyRangedAttack;
    }
}
