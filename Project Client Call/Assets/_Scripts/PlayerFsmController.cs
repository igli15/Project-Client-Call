using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFsmController : MonoBehaviour,IAgent
{

	[HideInInspector] 
	public Fsm<PlayerFsmController> fsm;
	
	void Start () 
	{
		if (fsm == null)
		{
			fsm = new Fsm<PlayerFsmController>(this);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			fsm.ChangeState<PlayerDeflectionState>();
		}

		if (Input.GetKeyUp(KeyCode.F))
		{
			fsm.ChangeState<PlayerNormalState>();
		}
	}
}
