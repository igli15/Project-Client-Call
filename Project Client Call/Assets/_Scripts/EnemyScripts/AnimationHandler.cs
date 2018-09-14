using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Action<AnimationHandler> OnThrowAnimation;

    public void CallOnThrowAnimation()
    {
        Debug.Log("OnthrowAnimation: " + OnThrowAnimation!=null);
        if (null != OnThrowAnimation) OnThrowAnimation(this);
    }

    public void CallOnDeath()
    {
        Debug.Log("ENEMY: I AM DEAD");
        Destroy(transform.parent.gameObject);
    }

}
