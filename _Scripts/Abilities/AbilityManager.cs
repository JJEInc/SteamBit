using System;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
	public static Teleport teleport = new Teleport();
	public static RealityShift realityshift = new RealityShift();
	public static Gaze gaze = new Gaze();

	#region teleport vars
	Vector2 start;
	float finalCost;
	public Transform playerTrans;
	public bool teleporting;
	public bool ableToTeleport;
	#endregion

	void Update()
	{
		#region teleport functionality
		// F == Teleport
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(!teleporting)
			{
				ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 1;
				ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 0;

				start = playerTrans.transform.position;
				teleport.InitiateTeleport();
				teleporting = true;

				ManaBar.abilityInUse = true;
			}
			else if(teleporting && ableToTeleport)
			{
				ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 0;
				ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 1;

				teleport.TerminateTeleport(finalCost);
				teleporting = false;

				ManaBar.abilityInUse = false;
			}
		}

		if(teleporting)
		{
			finalCost = Vector2.Distance(start, playerTrans.position);

			finalCost *= 5;

			ManaBar.manaSubBar.value = ManaBar.manabar.value - finalCost;

			if((ManaBar.manabar.value - finalCost) >= 0.0f)
			{
				ableToTeleport = true;
			}
			else
			{
				ableToTeleport = false;
			}
		}
		#endregion

		#region realityshift functionality
		// R == RealityShift
		if(Input.GetKeyDown(KeyCode.R) && !teleporting)
		{
			
		}
		#endregion

		#region gaze functionality
		// C == Gaze
		if(Input.GetKeyDown(KeyCode.C) && !teleporting)
		{
			
		}
		#endregion
	}
}
