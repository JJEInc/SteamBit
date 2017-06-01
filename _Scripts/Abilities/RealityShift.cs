using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealityShift {

	#region vars
	public enum Realities {
		steamPunk = 0,
		darkair = 1,
	};
	public static Realities currentReality = Realities.steamPunk;
	public bool ableToShift = true;
	#endregion

	/// <summary>
	/// Changes the reality for the specified object that comes at a cost
	/// </summary>
	/// <param name="objectToChangeRealities">The object to switch to the other reality.</param>
	/// <param name="cost">The cost associated with this reality shift.</param>
	public void ChangeReality(GameObject objectToChangeRealities, float cost)
	{
		if(ableToShift)
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

			// Change the camera and change the object position to be on the foreground. Deplete manabar.
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
}
