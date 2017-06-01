using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	#region vars
	public Transform cameraMove;
	public GameObject toFollow;
	Vector3 toFollowOffset;
	public float z;
	#endregion
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(toFollowOffset.x != toFollow.transform.position.x || toFollowOffset.y != toFollow.transform.position.y)
		{
			toFollowOffset = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, z);
		}

		cameraMove.transform.position = Vector3.Lerp(cameraMove.transform.position, toFollowOffset, Time.deltaTime);
	}
}
