
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField]
    string objectPoolTag;
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletPerShot = 1;
    [SerializeField]
    float delaybetweenBullet = 0;
    [SerializeField]
    float reloadTime;

    [SerializeField]
    float randomizeMultiplier = 0;
    [SerializeField]
    float bulletSpeed;

    float bulletPreShotCount;
    float initReloadTime;
    float lastTimeShot;
    private void Start()
    {
        initReloadTime = reloadTime;
        bulletPreShotCount = 0;
        lastTimeShot = 0;
    }

    public void ShootTo(Vector3 targetPosition)
    {
        if (Time.time < lastTimeShot + reloadTime) return; //Checking how much time passed since last shot
        lastTimeShot = Time.time;

        if (bulletPerShot > 0 && bulletPreShotCount<bulletPerShot)
        {
            bulletPreShotCount++;
            reloadTime = delaybetweenBullet;
        }
        if (bulletPerShot > 0 && bulletPreShotCount >= bulletPerShot)
        {
            ResetReloadTime();
        }

        Vector3 directionToShoot = targetPosition - transform.position;
        directionToShoot.Normalize();

        //Add randomization HERE <==================
        directionToShoot += new Vector3(0, (Random.value -0.5f )* randomizeMultiplier);
        GameObject newBullet = ObjectPooler.instance.SpawnFromPool(objectPoolTag, transform.position+ directionToShoot, Quaternion.identity); //Buller spawn
        newBullet.GetComponent<Rigidbody2D>().velocity = directionToShoot * bulletSpeed ;
    }

    public void ResetReloadTime()
    {
        bulletPreShotCount = 0;
        lastTimeShot = Time.time;
        reloadTime = initReloadTime;
    }

    public void SeetReloadZero()
    {
        lastTimeShot = 0;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}

