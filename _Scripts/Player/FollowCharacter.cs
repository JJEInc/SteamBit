using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour {

	public GameObject character;
	public GameObject toFollow;
	public float amountToFloat;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		toFollow.transform.position = new Vector2(character.transform.position.x, 
												  character.transform.position.y + amountToFloat);
	}
}
