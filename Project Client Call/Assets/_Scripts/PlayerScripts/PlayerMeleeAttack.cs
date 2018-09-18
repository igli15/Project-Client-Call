using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    float meleeAttackDistance = 1;
    [SerializeField]
    float reloadTime=1;
    private float meleeCount = 0;
    
    [HideInInspector]
    public float finishCount = 0;

    float lastTimeOfMelee;
    Rigidbody2D rb;
    PlayerAnimations playerAnimations;
    PlayerMovement movement;
 
    void Start () {
        lastTimeOfMelee = 0;
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
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
                    AudioManagerScript.instance.PlaySound("SwordKill");
                    raycast2d[i].collider.GetComponent<EnemyOnKneeState>().FinishHim();
                    raycast2d[i].collider.GetComponent<EnemyFsmController>().PlayBloodParticleSystem(raycast2d[i].collider.transform);
                }
                else
                {
                    meleeCount += 1;
                    AudioManagerScript.instance.PlaySound("SwordKill");
                    raycast2d[i].collider.GetComponent<EnemyFsmController>().PlayBloodParticleSystem(raycast2d[i].collider.transform);
                    raycast2d[i].collider.GetComponent<Health>().InflictDamage(100);
                    raycast2d[i].collider.GetComponent<EnemyFsmController>().PlayBloodParticleSystem(raycast2d[i].collider.transform);
                }

            }
        }

        
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (Time.time < lastTimeOfMelee + reloadTime) return;
            AudioManagerScript.instance.PlaySound("Melee");
            lastTimeOfMelee = Time.time;
            if (movement.IsGrounded)
            {
                rb.velocity = Vector2.zero;
                movement.canMoveHorizontally = false;
                StartCoroutine(WaitTillMeleeFinishes(0.5f));
            }
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

    IEnumerator WaitTillMeleeFinishes(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        movement.canMoveHorizontally = true;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * meleeAttackDistance);
    }
}
