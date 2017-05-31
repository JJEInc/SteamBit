using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour {

	public static Camera steampunk;
	public static Camera darkair;

	static string currCamera = "SteamPunkCamera";

	void Awake()
	{
		steampunk = GameObject.FindGameObjectWithTag("steampunkCamera").GetComponent<Camera>();
		darkair = GameObject.FindGameObjectWithTag("darkairCamera").GetComponent<Camera>();
	}

	public static void SwitchCamera()
	{
		switch(currCamera)
		{
		case "SteamPunkCamera":
			currCamera = darkair.name;
			steampunk.enabled = false;
			darkair.enabled = true;
			break;
		case "DarkairCamera":
			currCamera = steampunk.name;
			steampunk.enabled = true;
			darkair.enabled = false;
			break;
		default:
			currCamera = steampunk.name;
			steampunk.enabled = true;
			darkair.enabled = false;
			break;
		}
	}
}
