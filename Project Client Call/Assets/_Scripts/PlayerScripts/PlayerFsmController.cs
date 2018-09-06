using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFsmController : MonoBehaviour,IAgent
{

	[HideInInspector] 
	public Fsm<PlayerFsmController> fsm;

	public Slider slowMoSlider;
	
	
	void Start () 
	{
		if (fsm == null)
		{
			fsm = new Fsm<PlayerFsmController>(this);
		}
	}

	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.F ) ||  Input.GetKeyDown(KeyCode.Joystick1Button4))
		{
			if (fsm.GetCurrentState() is PlayerSlowMotionState)
			{
				fsm.ChangeState<PlayerNormalState>();
			}
			else if(slowMoSlider.value >= 1)
			{
				fsm.ChangeState<PlayerSlowMotionState>();
			}
		}

	}
}
