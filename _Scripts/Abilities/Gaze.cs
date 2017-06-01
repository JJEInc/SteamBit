using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze {

	#region vars
	public bool gazing;
	public bool ableToGaze = true;
	public GameObject gaze_steampunk;
	public GameObject gaze_darkair;
	public GameObject currGaze;
	#endregion

	/// <summary>
	/// Initiates the Gaze ability.
	/// </summary>
	public void GazeAbility()
	{
		// Switches the current gaze based on the current reality
		switch(RealityShift.currentReality)
		{
		case RealityShift.Realities.steamPunk:
			currGaze = gaze_steampunk;
			break;
		case RealityShift.Realities.darkair:
			currGaze = gaze_darkair;
			break;
		default:
			currGaze = gaze_steampunk;
			break;
		}

		// Sets the gaze visible or not
		if(ableToGaze && !gazing)
		{
			currGaze.SetActive(true);

			ManaBar.abilityInUse = true;
			gazing = true;
		}
		else if(gazing)
		{
			currGaze.SetActive(false);

			ManaBar.abilityInUse = false;
			gazing = false;
		}
	}
}
