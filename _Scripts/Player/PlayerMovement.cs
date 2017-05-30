using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Transform player;
	public float movement = 0.1f;
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		if(Input.GetKey(KeyCode.A))
		{
			player.position = new Vector2(player.position.x - movement, player.position.y);
		}

		if(Input.GetKey(KeyCode.D))
		{
			player.position = new Vector2(player.position.x + movement, player.position.y);
		}

		if(Input.GetKey(KeyCode.W))
		{
			player.position = new Vector2(player.position.x, player.position.y + movement);
		}

		if(Input.GetKey(KeyCode.S))
		{
			player.position = new Vector2(player.position.x, player.position.y - movement);
		}
	}
}
