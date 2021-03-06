﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public GameObject target; //Creates a variable called target
    public float followLag = 0.3f;
    public float xOffset = 4.05f;
    public float yOffset = -3.0f;
    public float cameraSize = 5.95f;
    public float shakeTimer = 0f;
    public float shakeWeight = 0.1f;

    private Vector3 currVelocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Camera>().orthographicSize = cameraSize; 
        
	}
	
	// Updates the camera position to follow the player
	void LateUpdate () {        
        Vector3 targetPosition = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * followLag);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currVelocity, followLag);
        

        if(shakeTimer > 0) {
            transform.position = transform.position + Random.insideUnitSphere * shakeWeight;
            shakeTimer = shakeTimer - Time.deltaTime;
        } else {
            shakeTimer = 0f;            
        }
		
	}

   
}
