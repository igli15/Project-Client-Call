using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraArenaState : AbstractState<CameraFsmController>
{

	[SerializeField] 
	private float zOffset = 6;

	[SerializeField] 
	private float offsetTime = 0.3f;

	private Vector3 initPos;
	private Vector3 offsetedPos;

	public static Sequence Sequence;

	// Use this for initialization
	void Start ()
	{
		Sequence = DOTween.Sequence();
	}

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);


		Sequence.Append(transform.DOMoveZ(transform.position.z - zOffset, offsetTime));

	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		Sequence.Append(transform.DOMoveZ(transform.position.z + zOffset, offsetTime));
		Sequence.SetAutoKill();
	}
	
}
