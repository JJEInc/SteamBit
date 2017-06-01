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
	Vector2 finalWorldPos;
	Vector2 start;
	float finalCost;
	#endregion

	#region realityshift vars
	float realityShiftCost = 25.0f;
	#endregion

	#region gaze vars
	GameObject currGaze;
	#endregion

	void Awake()
	{
		gaze.gaze_steampunk = GameObject.Find("Gaze_OfDarkair");
		gaze.gaze_darkair = GameObject.Find("Gaze_OfSteamPunk");

		gaze.gaze_steampunk.SetActive(false);
		gaze.gaze_darkair.SetActive(false);

		teleport.teleportCursor = GameObject.Find("TeleportCursor");

		teleport.teleportCursor.SetActive(false);
	}

	void Update()
	{
		#region (manual) teleport functionality
		// F == Teleport
		if(Input.GetKeyDown(KeyCode.F) && !gaze.gazing)
		{
			teleport.TeleportAbility(ref start, player, ref finalCost);
		}
		#endregion

		#region (auto) teleport functionality
		// RightClick == Teleport
		if(Input.GetMouseButtonDown(1) && !gaze.gazing)
		{
			teleport.TeleportAbility(ref start, player, ref finalCost, true);
		}
		else if(Input.GetMouseButtonUp(1) && !gaze.gazing)
		{
			teleport.TeleportAbility(ref start, player, ref finalCost, true, finalWorldPos);
		}
		#endregion

		#region teleport functions
		if(teleport.teleporting)
		{
			teleport.TeleportLogic(start, player, teleport.teleportCursor, ref finalWorldPos, ref finalCost);
		}
		#endregion

		#region realityshift functionality
		// R == RealityShift
		if(Input.GetKeyDown(KeyCode.R) && !teleport.teleporting && !gaze.gazing)
		{
			realityshift.ChangeReality(player, realityShiftCost);
		}
		#endregion

		#region gaze functionality
		// C == Gaze
		if(Input.GetKeyDown(KeyCode.C) && !teleport.teleporting)
		{
			gaze.GazeAbility();
		}

		if(gaze.gazing)
		{
			ManaBar.Deplete(0.025f);
		}
		#endregion
	}
}
