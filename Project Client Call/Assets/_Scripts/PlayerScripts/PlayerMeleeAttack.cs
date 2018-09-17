using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    float meleeAttackDistance = 1;

    private float meleeCount = 0;
    
    [HideInInspector]
    public float finishCount = 0;

    PlayerAnimations playerAnimations;
    void Start () {
        playerAnimations = GetComponent<PlayerAnimations>();
        PlayerAnimationHandler.OnMeleeAttackAnimationFinished += OnAnimFinished;
	}

    void OnAnimFinished(PlayerAnimationHandler sender)
    {
        int layerMask = 1 << 11 | (1 << 9);

        Vector2 size = Vector2.one;
        
        RaycastHit2D[] raycast2d = Physics2D.BoxCastAll(transform.position, size,0, transform.right, meleeAttackDistance,layerMask);

        for (int i = 0; i < raycast2d.Length; i++)
        {
            if (raycast2d[i].collider != null && (raycast2d[i].collider.transform.CompareTag("Enemy")))
            {
                if (raycast2d[i].collider.GetComponent<EnemyOnKneeState>().enabled)
                {
                    
                    raycast2d[i].collider.GetComponent<EnemyOnKneeState>().FinishHim();
                }
                else
                {
                    meleeCount += 1;
                    raycast2d[i].collider.GetComponent<Health>().InflictDamage(100);
                }

            }
        }

        
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerAnimations.SetAttack();
        }

	    if (meleeCount >= 20)
	    {
	        AchievementPopUp.QueueAchievement("Melee Attack");
	        meleeCount = 0;
	    }

	    if (finishCount >= 20)
	    {
	        AchievementPopUp.QueueAchievement("Finish Him");
	        finishCount = 0;
	    }
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * meleeAttackDistance);
    }
}
