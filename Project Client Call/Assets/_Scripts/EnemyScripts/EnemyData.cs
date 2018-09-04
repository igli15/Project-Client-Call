using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;

     static Action<EnemyData> OnMovementSpeedChanged;

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
