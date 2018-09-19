
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
    float randomizeMultiplier = 0;

    [SerializeField]
    float horizontalOffsetOfShooting=1;
    [SerializeField]
    float verticalOffsetOfShooting = 0;
    float bulletPreShotCount;
    float initReloadTime;
    float lastTimeShot;

    private EnemyFsmController enemyFsmController;

    EnemyData enemyData;
    private void Start()
    {
        enemyData = GetComponent<EnemyData>();
        initReloadTime = enemyData.BulletSpeed;
        bulletPreShotCount = 0;
        lastTimeShot = 0;
        enemyFsmController = GetComponent<EnemyFsmController>();
        enemyData.AnimHandler.OnThrowAnimation += ActualShootToTarget;
    }

    public void ShootTo(Vector3 targetPosition)
    {
        //if (Time.time <= lastTimeShot + enemyData.ReloadSpeed) return; //Checking how much time passed since last shot
        //lastTimeShot = Time.time;

        if (enemyFsmController.GetEnemyType == EnemyFsmController.EnemyType.Cannoneer)
        {
            AudioManagerScript.instance.PlaySound("CannonFuse");
        }
            
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
        if (enemyFsmController.GetEnemyType == EnemyFsmController.EnemyType.Cannoneer)
        {
            AudioManagerScript.instance.PlaySound("CannonShot");
        }
        else
        {
            AudioManagerScript.instance.PlaySound("ShurikenThrow");
        }

        Vector3 directionToShoot = enemyData.Player.transform.position - transform.position;
        directionToShoot.Normalize();
        for (int i = 0; i < enemyData.BulletPerShot; i++)
        {
            directionToShoot += new Vector3(0, (Random.value - 0.5f) * randomizeMultiplier);
            GameObject newBullet = ObjectPooler.instance.SpawnFromPool(objectPoolTag, transform.position +transform.up*verticalOffsetOfShooting+transform.right*horizontalOffsetOfShooting, Quaternion.identity); //Buller spawn
            newBullet.GetComponent<Rigidbody2D>().velocity = directionToShoot * enemyData.BulletSpeed;
        }
    }

    public void ResetReloadTime()
    {
       // bulletPreShotCount = 0;
        lastTimeShot = Time.time;
        //enemyData.BulletSpeed = initReloadTime;
    }

    public void SeetReloadZero()
    {
        lastTimeShot = 0;
    }

    public float GetBulletSpeed()
    {
        return enemyData.BulletSpeed;
    }
}

