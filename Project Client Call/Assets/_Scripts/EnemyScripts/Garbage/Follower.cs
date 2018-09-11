using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public Transform transformToFollow;
    Vector3 offset;
    void Start () {
        offset =- transformToFollow.position + transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transformToFollow.position+ offset;

    }
}
