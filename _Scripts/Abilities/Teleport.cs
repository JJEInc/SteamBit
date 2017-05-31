using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport {

	public void ActivateTeleport(GameObject player)
	{
		ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 1;
		ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 0;

		AbilityManager.realityshift.ChangeReality(player, 0.0f);

		ManaBar.abilityInUse = true;
	}

	public void DeactivateTeleport(GameObject player, float cost)
	{
		ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 0;
		ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 1;

		AbilityManager.realityshift.ChangeReality(player, 0.0f);

		ManaBar.Deplete(cost);
		ManaBar.abilityInUse = false;
	}
}
