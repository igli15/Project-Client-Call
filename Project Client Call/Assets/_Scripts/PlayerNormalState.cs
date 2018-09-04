using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : AbstractState<PlayerFsmController>
{

	private RotateWithMouse rotateWithMouse;
	
	// Use this for initialization
	void Start ()
	{
		rotateWithMouse = GetComponentInChildren<RotateWithMouse>();
	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);

		rotateWithMouse.enabled = false;
	}

}
