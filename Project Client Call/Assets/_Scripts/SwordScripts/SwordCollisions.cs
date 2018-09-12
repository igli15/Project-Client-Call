using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private PlayerAnimations playerAnimations;

    [SerializeField] private GameObject swoosh;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            swoosh.SetActive(true);
            swoosh.transform.parent = null;
        }
    }
    
 

    private void CheckForAngleCollision()   //NOTE not needed now keep just in case
    {
        float angle = Utils.Find360Angle(playerRb.transform.right, transform.right);

        if ((angle >= 0 && angle <= 25) || (angle <= 360 && angle >= 335))
        {
            Debug.Log("Forward slash");
            playerAnimations.Swoosh();
        }
        else if (angle > 25 && angle < 80)
        { 
            playerAnimations.Swoosh();
            Debug.Log("UpForwardSlash");
        }
        else if (angle >= 80 && angle < 110)
        {
            Debug.Log("UpSlash");
        }
        else if (angle >= 110 && angle < 155)
        {
            Debug.Log("UpBackwardsSlash");
        }
        else if (angle >= 155 && angle < 205)
        {
            Debug.Log("BackwardsSlash");
        }
        else if (angle >= 205 && angle < 245)
        {
            Debug.Log("DownBackwardsSlash");
        }
        else if (angle >= 245 && angle < 305)
        {
            Debug.Log("DownwardsSlash");
        }
        else if (angle >= 305 && angle < 335)
        {
            Debug.Log("ForwardDownSlash");
        }
    }

    
}