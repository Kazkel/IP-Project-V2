using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public GameObject target; //Creates a variable called target
    public float followLag = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Updates the camera position to follow the player
	void LateUpdate () {
        Vector3 targetPos = new Vector3(target.transform.position.x + 6.6f, target.transform.position.y + 2f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followLag);
	}
}
