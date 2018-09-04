using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float reloadTime;
    [SerializeField]
    float bulletSpeed;

    float lastTimeShot;
    private void Start()
    {
        lastTimeShot = 0;
    }

    private void FixedUpdate()
    {
    }

    public void ShootTo(Vector3 targetPosition)
    {
        if (Time.time < lastTimeShot + reloadTime) return;
        lastTimeShot = Time.time;
        Vector3 directionToShoot = targetPosition - transform.position;
        directionToShoot.Normalize();

        GameObject newBullet = Instantiate(bullet, transform.position+ directionToShoot, transform.rotation, null);
        newBullet.GetComponent<Rigidbody2D>().velocity = directionToShoot * bulletSpeed;
    }
}

