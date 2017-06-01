using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Teleport {

	#region vars
	public bool teleporting;
	public bool ableToTeleport;
	public GameObject teleportCursor;
	public Color activeColor = Color.red;
	public Color notActiveColor = Color.black;
	#endregion

	/// <summary>
	/// Teleports the player.
	/// </summary>
	/// <param name="start">Start.</param>
	/// <param name="player">Player.</param>
	/// <param name="finalCost">Final cost.</param>
	/// <param name="auto">If set to <c>true</c> auto.</param>
	/// <param name="finalWorldPos">Final world position.</param>
	public void TeleportAbility(ref Vector2 start, GameObject player, ref float finalCost, 
								bool auto = false, Vector2 finalWorldPos = new Vector2())
	{
		if(!teleporting)
		{
			start = player.transform.position;

			ManaBar.abilityInUse = true;
			teleporting = true;

			ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 1;
			ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 0;

			if(auto)
			{
				teleportCursor.SetActive(true);
			}
			else
			{
				AbilityManager.realityshift.ChangeReality(player, 0.0f);
			}
		}
		else if(teleporting)
		{
			if(ableToTeleport)
			{
				ManaBar.abilityInUse = false;
				teleporting = false;

				ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 0;
				ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 1;
				ManaBar.Deplete(finalCost);

				if(auto)
				{
					teleportCursor.SetActive(false);

					player.transform.position = new Vector3(finalWorldPos.x, finalWorldPos.y, player.transform.position.z);
				}
				else
				{
					AbilityManager.realityshift.ChangeReality(player, 0.0f);
				}
			}
			else
			{
				if(auto)
				{
					ManaBar.abilityInUse = false;
					teleporting = false;

					ManaBar.manaSubBar.GetComponent<CanvasGroup>().alpha = 0;
					ManaBar.manabar.GetComponent<CanvasGroup>().alpha = 1;

					teleportCursor.SetActive(false);
				}
			}
		}
	}

	/// <summary>
	/// The logic behind teleporting the player.
	/// </summary>
	/// <param name="start">Start vector.</param>
	/// <param name="player">Player object.</param>
	/// <param name="teleportCursor">Teleport cursor object.</param>
	/// <param name="finalWorldPos">Final world position vector.</param>
	/// <param name="finalCost">Final cost.</param>
	public void TeleportLogic(Vector2 start, GameObject player, GameObject teleportCursor, 
							  ref Vector2 finalWorldPos, ref float finalCost)
	{
		// If the cursor is active, we are using auto, else we calculate the cost right away
		if(teleportCursor.activeSelf)
		{
			// We map the mouse position to the world to calculate the correct distance
			var mousePosition = Input.mousePosition;
			teleportCursor.transform.position = mousePosition;
			finalWorldPos = CameraManager.currCamera.ScreenToWorldPoint(mousePosition);

			finalCost = Vector2.Distance(start, finalWorldPos);
		}
		else
		{
			finalCost = Vector2.Distance(start, player.transform.position);
		}

		// Subtract amount from the manabar
		finalCost *= 5;
		ManaBar.manaSubBar.value = ManaBar.manabar.value - finalCost;

		// If the final value is above 0, we are able to teleport and set the color to the active color
		// else we cannot teleport and set the color to not active.
		if((ManaBar.manaSubBar.value) > 0.0f)
		{
			ableToTeleport = true;

			if(teleportCursor.activeSelf && !(teleportCursor.GetComponent<RawImage>().color == activeColor))
			{
				teleportCursor.GetComponent<RawImage>().color = activeColor;
			}
		}
		else
		{
			ableToTeleport = false;

			if(teleportCursor.activeSelf && !(teleportCursor.GetComponent<RawImage>().color == notActiveColor))
			{
				teleportCursor.GetComponent<RawImage>().color = notActiveColor;
			}
		}
	}
}
