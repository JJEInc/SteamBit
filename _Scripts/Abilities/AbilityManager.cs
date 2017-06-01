using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
	public static Teleport teleport = new Teleport();
	public static RealityShift realityshift = new RealityShift();
	public static Gaze gaze = new Gaze();

	public GameObject player;

	#region teleport vars
	Vector2 start;
	float finalCost;
	//public Transform playerTrans;
	public bool teleporting;
	public bool ableToTeleport;
	public GameObject teleportCursor;
	public Color activeColor;
	public Color notActiveColor;
	Vector2 finalWorldPos;
	#endregion

	#region realityshift vars
	public bool shifting;
	public bool ableToShift = true;
	public float realityShiftCost = 25.0f;
	#endregion

	#region gaze vars
	public bool gazing;
	public bool ableToGaze = true;
	public GameObject gaze_steampunk;
	public GameObject gaze_darkair;
	GameObject currGaze;
	#endregion

	void Update()
	{
		#region (manual) teleport functionality
		// F == Teleport
		if(Input.GetKeyDown(KeyCode.F) && !shifting && !gazing)
		{
			if(!teleporting)
			{
				start = player.transform.position;
				teleport.ActivateTeleport(player);
				teleporting = true;
			}
			else if(teleporting && ableToTeleport)
			{
				teleport.DeactivateTeleport(player, finalCost);
				teleporting = false;			
			}
		}
		#endregion

		#region (auto) teleport functionality
		// RightClick == Teleport
		if(Input.GetMouseButtonDown(1) && !shifting && !gazing)
		{
			if(!teleporting)
			{
				start = player.transform.position;
				teleport.AutoActivateTeleport();
				teleporting = true;

				teleportCursor.SetActive(true);
			}
		}
		else if(Input.GetMouseButtonUp(1) && !shifting && !gazing)
		{
			if(teleporting)
			{
				teleport.AutoDeactivateTeleport(finalCost);
				teleporting = false;

				teleportCursor.SetActive(false);

				if(ableToTeleport)
				{
					player.transform.position = finalWorldPos;
				}
			}
		}
		#endregion

		#region teleport functions
		if(teleporting)
		{
			if(teleportCursor.activeSelf)
			{
				var mousePosition = Input.mousePosition;
				teleportCursor.transform.position = mousePosition;
				finalWorldPos = CameraManager.currCamera.ScreenToWorldPoint(mousePosition);

				finalCost = Vector2.Distance(start, finalWorldPos);
			}
			else
			{
				finalCost = Vector2.Distance(start, player.transform.position);
			}

			finalCost *= 5;

			ManaBar.manaSubBar.value = ManaBar.manabar.value - finalCost;

			if((ManaBar.manabar.value - finalCost) >= 0.0f)
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
		#endregion

		#region realityshift functionality
		// R == RealityShift
		if(Input.GetKeyDown(KeyCode.R) && !teleporting && !gazing)
		{
			if(ableToShift)
			{
				realityshift.ChangeReality(player, realityShiftCost);
			}
		}
		#endregion

		#region gaze functionality
		// C == Gaze
		if(Input.GetKeyDown(KeyCode.C) && !teleporting && !shifting)
		{
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

			if(ableToGaze && !gazing)
			{
				gaze.ActivateGaze(currGaze);
				gazing = true;
			}
			else if(gazing)
			{
				gaze.DeactivateGaze(currGaze);
				gazing = false;
			}
		}

		if(gazing)
		{
			ManaBar.Deplete(0.025f);
		}
		#endregion
	}
}
