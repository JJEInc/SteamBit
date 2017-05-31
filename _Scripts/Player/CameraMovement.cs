using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform cameraMove;
	public GameObject toFollow;
	Vector3 toFollowOffset;
	public float z;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(toFollowOffset.x != toFollow.transform.position.x)
		{
			toFollowOffset = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, z);
		}

		cameraMove.transform.position = Vector3.Lerp(cameraMove.transform.position, toFollowOffset, Time.deltaTime);
	}
}
