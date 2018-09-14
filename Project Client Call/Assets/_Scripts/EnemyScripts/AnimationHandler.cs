using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Action<AnimationHandler> OnThrowAnimation;

    [SerializeField] 
    private HighScoreManager highScoreManager;

    public void CallOnThrowAnimation()
    {
        if (null != OnThrowAnimation) OnThrowAnimation(this);
    }

    public void CallOnDeath()
    {
        Debug.Log("ENEMY: I AM DEAD");
        highScoreManager.InreaseKillScore();
        Destroy(transform.parent.gameObject);
    }

}
