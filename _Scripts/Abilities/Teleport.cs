using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport {

	public void InitiateTeleport()
	{
		AbilityManager.realityshift.ChangeReality();
	}

	public void TerminateTeleport(float cost)
	{
		AbilityManager.realityshift.ChangeReality();

		ManaBar.Deplete(cost);
	}
}
