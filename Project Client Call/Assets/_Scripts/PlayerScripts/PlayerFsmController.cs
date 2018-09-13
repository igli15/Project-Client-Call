using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFsmController : MonoBehaviour,IAgent
{

	[HideInInspector] 
	public Fsm<PlayerFsmController> fsm;

	public Slider slowMoSlider;
    bool isDead;
	
	void Start () 
	{
		if (fsm == null)
		{
			fsm = new Fsm<PlayerFsmController>(this);
		}
        isDead = false;
        GetComponent<Health>().OnDeath += OnDeath;
	}

    void OnDeath(Health health)
    {
        fsm.ChangeState<PlayerDeadState>();
        isDead = true;
        GetComponent<PlayerMovement>().enabled = false;

    }

	private void Update()
	{
        if (isDead) return;	
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
