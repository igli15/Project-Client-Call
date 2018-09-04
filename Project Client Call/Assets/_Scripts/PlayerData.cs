using System;
using System.Collections;
using System.Collections.Generic;
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

    public static Action<PlayerData> OnMovementSpeedChanged;

    public void ChangeMovementSpeed(int value)
    {
        if (OnMovementSpeedChanged != null) OnMovementSpeedChanged(this);
        movementSpeed += value;
    }
    
    
    //Getters
    public float MovementSpeed()
    {
        return movementSpeed;
    }
}
