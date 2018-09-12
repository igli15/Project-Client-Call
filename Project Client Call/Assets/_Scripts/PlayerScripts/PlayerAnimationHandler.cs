using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{

	public static Action<PlayerAnimationHandler> PlayerAnimHandler;

	public void CallHandlers()
	{
		if (PlayerAnimHandler != null) PlayerAnimHandler(this);
	}
}
