using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float speedOfRotation=1;
    
    private void FixedUpdate()
    {
        //transform.Rotate(new Vector3(0, 0, speedOfRotation));
    }

}

