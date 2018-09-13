using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    float meleeAttackDistance = 1;

    PlayerAnimations playerAnimations;
    void Start () {
        playerAnimations = GetComponent<PlayerAnimations>();
        PlayerAnimationHandler.OnMeleeAttackAnimationFinished += OnAnimFinished;
	}

    void OnAnimFinished(PlayerAnimationHandler sender)
    {
        int layerMask = 1 << 11 | (1 << 9);
        
        RaycastHit2D[] raycast2d = Physics2D.RaycastAll(transform.position, transform.right* meleeAttackDistance, meleeAttackDistance, layerMask);

        for (int i = 0; i < raycast2d.Length; i++)
        {
            if (raycast2d[i].collider != null && (raycast2d[i].collider.transform.CompareTag("Enemy")))
            {
                raycast2d[i].collider.GetComponent<Health>().InflictDamage(100);
                Debug.Log("Enemy: "+ raycast2d [i].collider.name+ "is Killed by melee");
            }
        }

        
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Attack");
            playerAnimations.SetAttack();
        }
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * meleeAttackDistance);
    }
}
