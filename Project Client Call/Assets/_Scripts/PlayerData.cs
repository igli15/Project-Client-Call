using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/*
 *  Use this class to store all player flieds. example: movement speed, jump speed etc....
 *  All fields are private and can be changed by setters only.
 *  No behaviour/functions go here expept setting the player values.
 *  Look At movement speed as an exmaple.
 */

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;

    [SerializeField] 
    private float jumpSpeed = 5;

    private float inititalMovementSpeed;

    public static Action<PlayerData> OnMovementSpeedChanged;

    private void Start()
    {
        inititalMovementSpeed = movementSpeed;
    }

    public void ChangeMovementSpeed(int value)
    {    
        if (OnMovementSpeedChanged != null) OnMovementSpeedChanged(this);
        movementSpeed += value;
    }

    /*public void TweenSlide(float timeToslowDown,float timeToSpeedUp ,float movementSpeedAddition)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(x => movementSpeed = x, movementSpeed, movementSpeed + movementSpeedAddition, 0.2f));
        sequence.Append(DOTween.To(x => movementSpeed = x, movementSpeed, 0, timeToslowDown));
 
    }*/

    public void ResetMovementSpeed()
    {
        movementSpeed = inititalMovementSpeed;
    }
    
    //Getters
    public float MovementSpeed()
    {
        return movementSpeed;
    }
    
    public float JumpSpeed()
    {
        return jumpSpeed;
    }
}
