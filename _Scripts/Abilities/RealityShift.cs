using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealityShift {

	public enum Realities {
		steamPunk = 0,
		darkair = 1,
	};
	public static Realities currentReality = Realities.steamPunk;

	/// <summary>
	/// Changes the reality.
	/// Use: Used on the OnClick function of buttons. 0 = SteamPunk, 1 = Victorian for input parameters.
	///		This is just for testing purposes, we will integrate better when the time comes.
	/// </summary>
	/// <param name="reality">Reality.</param>
	public void ChangeReality(GameObject objectToChangeRealities, float cost)
	{
		// Switch to the opposite reality we are currently in
		switch(currentReality)
		{
		case Realities.steamPunk:
			currentReality = Realities.darkair;
			break;
		case Realities.darkair:
			currentReality = Realities.steamPunk;
			break;
		default:
			currentReality = Realities.darkair;
			break;
		}
		// TODO Add animations, sound change, etc.
		CameraManager.SwitchCamera();

		float z;

		switch(RealityShift.currentReality)
		{
		case RealityShift.Realities.steamPunk:
			z = -3;
			break;
		case RealityShift.Realities.darkair:
			z = 17;
			break;
		default:
			z = -3;
			break;
		}

		var pos = objectToChangeRealities.transform.position;
		objectToChangeRealities.transform.position = new Vector3(pos.x, pos.y, z);

		ManaBar.Deplete(cost);

	}
}
