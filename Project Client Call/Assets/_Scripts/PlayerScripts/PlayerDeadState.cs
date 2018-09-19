using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : AbstractState<PlayerFsmController>
{

	[SerializeField] 
	private GameObject endScreenCanvas;

    // Use this for initialization
    void Start () {
		
	}

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        GetComponent<PlayerAnimations>().SetIsDead();
        GetComponent<PlayerAnimations>().SetJumpingToFalse();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<PlayerMeleeAttack>().enabled = false;
		endScreenCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
