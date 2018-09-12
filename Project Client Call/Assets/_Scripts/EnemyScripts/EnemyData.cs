using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;
    [SerializeField]
    AnimationHandler animHandler;
    private float initMovementSpeed;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initMovementSpeed = movementSpeed;
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    public void ResetMovementSpeed()
    {
        movementSpeed = initMovementSpeed;
    }
    public GameObject Player
    {
        get { return player; }
    }
    public AnimationHandler AnimHandler
    {
        get { return animHandler; }
    }

}
