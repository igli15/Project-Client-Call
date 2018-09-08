using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;
    
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }    

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    public GameObject Player
    {
        get { return player; }
    }
}
