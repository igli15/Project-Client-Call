using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : AbstractState<PlayerFsmController>
{ 

    // Use this for initialization
    void Start () {
		
	}

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        GetComponent<PlayerAnimations>().SetIsDead();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("ENTER DEAD STATE");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
