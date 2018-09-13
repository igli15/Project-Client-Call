using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{

	public static Action<PlayerAnimationHandler> PlayerAnimHandler;
    public static Action<PlayerAnimationHandler> OnMeleeAttackAnimationFinished;

    public void CallHandlers()
	{
		if (PlayerAnimHandler != null) PlayerAnimHandler(this);
	}

    public void CallOnPlayerDestroy()
    {
        gameObject.tag = "Untagged";
        // Destroy(transform.parent.gameObject);
    }

    public void CallOnMeleeAttack()
    {
        if (OnMeleeAttackAnimationFinished != null) OnMeleeAttackAnimationFinished(this);
    }

    public void OnDestroy()
    {
        PlayerAnimHandler = null;
        OnMeleeAttackAnimationFinished = null;
    }
}
