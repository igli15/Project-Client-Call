using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Action<AnimationHandler> OnThrowAnimation;

    public void CallOnThrowAnimation()
    {
        Debug.Log("ANIMATION CALLED SOMETHING");
        if (null != OnThrowAnimation) OnThrowAnimation(this);
    }

}
