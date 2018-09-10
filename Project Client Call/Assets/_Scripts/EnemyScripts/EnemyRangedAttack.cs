using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField]
    string tag;
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

    public void ShootTo(Vector3 targetPosition)
    {
        if (Time.time < lastTimeShot + reloadTime) return;
        lastTimeShot = Time.time;
        Vector3 directionToShoot = targetPosition - transform.position;
        directionToShoot.Normalize();

        GameObject newBullet = ObjectPooler.instance.SpawnFromPool(tag, transform.position+ directionToShoot, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = directionToShoot * bulletSpeed ;
    }


    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}

