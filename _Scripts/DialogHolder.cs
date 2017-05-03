// Attached to the character you are talking to, not the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

	// Input the character dialogs you would like to in the inspector
	public List<TextAsset> dialogs;
	// Change to important in inspector if this is important
	public bool isImportant;
	public int currDialog = 0;
}
