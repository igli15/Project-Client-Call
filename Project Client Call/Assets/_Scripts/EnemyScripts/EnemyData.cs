using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;
    [Header("RangedAttack")]

    ////////////////HARD
    [SerializeField]
    float hardBulletSpeed=10;
    [SerializeField]
    float hardReloadTime=1;
    [SerializeField]
    float hardBulletPerShot = 1;
    ////////////////EASY
    [SerializeField]
    private float normalBulletSpeed=7;
    [SerializeField]
    private float nomralReloadTime = 1.5f;
    [SerializeField]
    float normalBulletPerShot = 1;
    ////////////////ACTUAL
    private float bulletSpeed;
    private float reloadTime;
    private float bulletsPerShot;


    [SerializeField]
    AnimationHandler animHandler;
    private float initMovementSpeed;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initMovementSpeed = movementSpeed;
        int levelOfDificulties = PlayerPrefs.GetInt("levelOfDifficulty");
        if (levelOfDificulties == 0)
        {
            Debug.Log("NORMAL");
            bulletSpeed = normalBulletSpeed;
            bulletsPerShot = normalBulletPerShot;
            reloadTime = nomralReloadTime;
        }
        else
        {
            Debug.Log("HARD");
            bulletSpeed = hardBulletSpeed;
            bulletsPerShot = hardBulletPerShot;
            reloadTime = hardReloadTime;
        }
    }


    public float BulletSpeed { get { return bulletSpeed; } set { bulletSpeed = value; } }
    public float ReloadSpeed { get { return reloadTime; } }
    public float BulletPerShot { get { return bulletSpeed; } }

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
