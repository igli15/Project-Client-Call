using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Action<AnimationHandler> OnThrowAnimation;

    private PlayerMeleeAttack playerMeleeAttack;

    private void Start()
    {
        playerMeleeAttack = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerMeleeAttack>();
    }

    public void CallOnThrowAnimation()
    {
        if (null != OnThrowAnimation) OnThrowAnimation(this);
    }

    public void CallOnDeath()
    {
        Debug.Log("ENEMY: I AM DEAD");
        HighScoreManager.instance.InreaseKillScore();
        playerMeleeAttack.finishCount += 1;
        Destroy(transform.parent.gameObject);
    }

}
