using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeflectionState : AbstractState<PlayerFsmController>
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
		rotateWithMouse.enabled = true;
	}

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		rotateWithMouse.gameObject.transform.position = rotateWithMouse.initialDistanceFromPlayer + transform.position;
		rotateWithMouse.gameObject.transform.rotation = Quaternion.identity;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
