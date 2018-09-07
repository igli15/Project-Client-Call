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
 *  All the usage of the fields goes into the controllers!
 */

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;

    [SerializeField] 
    private float jumpSpeed = 5;

    [SerializeField]
    private float secondJumpSpeed = 12;


    private void Start()
    {
    
    }

    
    //Getters
    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }
    
    public float JumpSpeed
    {
        get
        {
            return jumpSpeed;
        }
        set
        {
            jumpSpeed = value;
        }
    }
    
    public float SecondJumpSpeed
    {
        get
        {
            return secondJumpSpeed;
        }
        set
        {
            secondJumpSpeed = value;
        }
    }

}
