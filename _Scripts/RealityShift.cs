using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealityShift : MonoBehaviour {

	public enum Realities {
		steamPunk = 0,
		victorian = 1,
	};
	public static Realities currentReality = Realities.steamPunk;
	public Text CurrRealityText;

	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Changes the reality.
	/// Use: Used on the OnClick function of buttons. 0 = SteamPunk, 1 = Victorian for input parameters.
	///		This is just for testing purposes, we will integrate better when the time comes.
	/// </summary>
	/// <param name="reality">Reality.</param>
	public void ChangeReality(int reality)
	{
		switch(reality)
		{
		case 0:
			currentReality = Realities.steamPunk;
			CurrRealityText.text = "SteamPunk : 0";
			break;
		case 1:
			currentReality = Realities.victorian;
			CurrRealityText.text = "Victorian : 1";
			break;
		default:
			currentReality = Realities.steamPunk;
			CurrRealityText.text = "SteamPunk : 0";
			break;
		}
		// TODO Add animations, sound change, etc.
	}
}
