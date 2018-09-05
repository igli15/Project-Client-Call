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
			if (fsm.GetCurrentState() is PlayerDeflectionState)
			{
				fsm.ChangeState<PlayerNormalState>();
				Debug.Log("1");
			}
			else
			{
				fsm.ChangeState<PlayerDeflectionState>();
				Debug.Log("2");
			}
		}

	}
}
