
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0168 
#pragma warning disable 0219
#pragma warning disable 0414

[RequireComponent(typeof(EnemyMovement))]
public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField]
    string objectPoolTag;

    [SerializeField]
    float bulletPerShot = 1;

    [SerializeField]
    float reloadTime;

    [SerializeField]
    float randomizeMultiplier = 0;
    [SerializeField]
    float bulletSpeed;

    float bulletPreShotCount;
    float initReloadTime;
    float lastTimeShot;

    EnemyData enemyData;
    private void Start()
    {
        initReloadTime = reloadTime;
        bulletPreShotCount = 0;
        lastTimeShot = 0;
        enemyData=GetComponent<EnemyData>();
        enemyData.AnimHandler.OnThrowAnimation += ActualShootToTarget;
    }

    public void ShootTo(Vector3 targetPosition)
    {
        if (Time.time < lastTimeShot + reloadTime) return; //Checking how much time passed since last shot
        lastTimeShot = Time.time;

        GetComponent<EnemyAnimations>().TrigerShootingAnimation(); // <============================== CALLING ANIMATION  || ANIMATION WILL CALL ACTUAL SHOOT FUNC.

        /*if (bulletPerShot > 0 && bulletPreShotCount<bulletPerShot)
        {
            bulletPreShotCount++;
            reloadTime = delaybetweenBullet;
        }
        if (bulletPerShot > 0 && bulletPreShotCount >= bulletPerShot)
        {
            ResetReloadTime();
        }*/
    }

    public void ActualShootToTarget(AnimationHandler animHandler)
    {
        Vector3 directionToShoot = enemyData.Player.transform.position - transform.position;
        directionToShoot.Normalize();
        for (int i = 0; i < bulletPerShot; i++)
        {
            directionToShoot += new Vector3(0, (Random.value - 0.5f) * randomizeMultiplier);
            GameObject newBullet = ObjectPooler.instance.SpawnFromPool(objectPoolTag, transform.position + directionToShoot, Quaternion.identity); //Buller spawn
            newBullet.GetComponent<Rigidbody2D>().velocity = directionToShoot * bulletSpeed;
        }
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

