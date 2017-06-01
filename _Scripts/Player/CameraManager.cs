using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour {

	#region vars
	static Camera steampunk;
	static Camera darkair;
	public static Camera currCamera;
	#endregion

	void Awake()
	{
		steampunk = GameObject.FindGameObjectWithTag("steampunkCamera").GetComponent<Camera>();
		darkair = GameObject.FindGameObjectWithTag("darkairCamera").GetComponent<Camera>();

		currCamera = steampunk;
	}

	/// <summary>
	/// Switchs the current camera.
	/// </summary>
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
