using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform cameraMove;
	public GameObject toFollow;
	public Vector3 toFollowOffset;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(toFollowOffset.x != toFollow.transform.position.x)
		{
			toFollowOffset = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, -10);
		}

		cameraMove.transform.position = Vector3.Lerp(cameraMove.transform.position, toFollowOffset, Time.deltaTime);
	}
}
