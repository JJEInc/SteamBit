using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour {

	#region CharacterBasedUI
	public Text pressEToInteract;
	// TODO Should we move this variable to characterManager or something??
	public bool isCharFacingRight;
	#endregion

	#region DialogVariables
	public static bool isTalking;
	public Camera otherCharCamera;
	public GameObject dialogBox;
	public Text dialogText;
	public RawImage charImage;
	public RawImage otherCharImage;
	#endregion


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.D) && !isCharFacingRight)
		{
			isCharFacingRight = true;
			FlipUI();
		}

		if(Input.GetKeyDown(KeyCode.A) && isCharFacingRight)
		{
			isCharFacingRight = false;
			FlipUI();
		}

		if(pressEToInteract.IsActive() && !isTalking)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				isTalking = true;
				pressEToInteract.enabled = false;
				InitiateDialogBox();
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ExitDialog();
		}
	}
	//TODO Temporary Fix for the E button UI - Switch this to a characterManager
	public void FlipUI()
	{
		float t = 1;
		if(!isCharFacingRight)
		{
			t = -1;
		}

		pressEToInteract.rectTransform.localScale = new Vector3(t, 1, 1);
	}

	public void InitiateDialogBox()
	{
		dialogBox.SetActive(true);
		// TODO Is there anything else we need to do here?
	}

	public void ExitDialog()
	{
		isTalking = false;
		dialogBox.SetActive(false);
	}

	public void SwapPlayerImagePositions()
	{
		bool swap = false;
		var charPos = charImage.transform.position;
		var otherCharPos = otherCharImage.transform.position;

		if(isCharFacingRight)
		{
			if(charPos.x > otherCharPos.x)
			{
				swap = true;
			}
		}
		else
		{
			if(charPos.x < otherCharPos.x)
			{
				swap = true;
			}
		}

		if(swap)
		{
			var temp = charPos;
			charImage.transform.position = otherCharPos;
			otherCharImage.transform.position = temp;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "npc")
		{
			// TODO Initiate talk sequence on button press, based on character name and some other variable maybe? Level Name?
			pressEToInteract.enabled = true;
			var charPos = col.gameObject.transform.FindChild("Head").transform.position;
			otherCharCamera.transform.position = new Vector3(charPos.x, charPos.y, -1);
			SwapPlayerImagePositions();
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "npc")
		{
			// TODO Deactivate initiation
			pressEToInteract.enabled = false;
		}

	}
}
