using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDeadState : AbstractState<PlayerFsmController>
{

	[SerializeField] 
	private GameObject endScreenCanvas;

	[SerializeField] 
	private float timeTillEndScreenActivation = 2f;

    [SerializeField]
    private AudioMixerSnapshot audioSS;

    // Use this for initialization
    void Start () 
    {
        AudioManagerScript.instance.PauseAllSounds();
        audioSS.TransitionTo(0f);
	}

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        GetComponent<PlayerAnimations>().SetIsDead();
        GetComponent<PlayerAnimations>().SetJumpingToFalse();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<PlayerMeleeAttack>().enabled = false;

	    DOVirtual.DelayedCall(timeTillEndScreenActivation, () => endScreenCanvas.SetActive(true));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
