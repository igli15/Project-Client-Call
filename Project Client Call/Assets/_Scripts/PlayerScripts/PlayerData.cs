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
    
    [Serializable]
    public struct JumpValues
    {
        public float jumpHeight;
        public float jumpCompletionTime;

    }

    [SerializeField]
    private float airborneSmoothedVelocity = 12;
    [SerializeField]
    private float groundedSmoothedVelocity = 14;
        
    [SerializeField]
    private float movementSpeed = 2;

    //[SerializeField] 
    private float jumpSpeed = 0;

   // [SerializeField]
    private float secondJumpSpeed = 12;

    [SerializeField] 
    private JumpValues firstJumpValues;

    [SerializeField]
    private JumpValues secondJumpValues;

    
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
    
    public float AirborneSmoothedVelocity
    {
        get
        {
            return airborneSmoothedVelocity;
        }
        set
        {
            airborneSmoothedVelocity = value;
        }
    }
    
    public float GroundedSmoothedVelocity
    {
        get
        {
            return groundedSmoothedVelocity;
        }
        set
        {
            groundedSmoothedVelocity = value;
        }
    }

    
    public JumpValues FirstJumpValues
    {
        get
        {
            return firstJumpValues;
        }
        set
        {
            firstJumpValues = value;
        }
    }
    
    public JumpValues SecondJumpValues
    {
        get
        {
            return secondJumpValues;
        }
        set
        {
            secondJumpValues = value;
        }
    }

}
