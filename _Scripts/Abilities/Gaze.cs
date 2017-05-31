using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze {

	public void ActivateGaze(GameObject currGaze)
	{
		currGaze.SetActive(true);

		ManaBar.abilityInUse = true;
	}

	public void DeactivateGaze(GameObject currGaze)
	{
		currGaze.SetActive(false);

		ManaBar.abilityInUse = false;
	}

}
