using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour {

	public static Camera steampunk;
	public static Camera darkair;

	public static Camera currCamera;

	void Awake()
	{
		steampunk = GameObject.FindGameObjectWithTag("steampunkCamera").GetComponent<Camera>();
		darkair = GameObject.FindGameObjectWithTag("darkairCamera").GetComponent<Camera>();

		currCamera = steampunk;
	}

	public static void SwitchCamera()
	{
		switch(currCamera.name)
		{
		case "SteamPunkCamera":
			currCamera = darkair;
			steampunk.enabled = false;
			darkair.enabled = true;
			break;
		case "DarkairCamera":
			currCamera = steampunk;
			steampunk.enabled = true;
			darkair.enabled = false;
			break;
		default:
			currCamera = steampunk;
			steampunk.enabled = true;
			darkair.enabled = false;
			break;
		}
	}
}
