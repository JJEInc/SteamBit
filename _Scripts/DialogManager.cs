using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class DialogManager : MonoBehaviour {

	#region CharacterBasedUI
	public Text pressEToInteract;
	// TODO Should we move this variable to characterManager or something??
	public bool isCharFacingRight;
	public bool isAbleToTalk;
	#endregion

	#region DialogVariables
	public GameObject otherChar;
	public GameObject dialogBox;
	public static bool isTalking;
	public static bool inProcessOfDisplayingDialog;
	public bool importantDialog;
	public Camera otherCharCamera;
	public Text dialogText;
	public RawImage charImage;
	public RawImage otherCharImage;
	public static string[] dialog;
	public static int currDialogPos = 0;
	public string currDialogText;
	public int currPosInString = 0;
	public static float timeToDisplay = 0.065f;
	#endregion


	public static Text[] characters;

	void Awake()
	{
		characters = GameObject.Find("TextHolder").GetComponentsInChildren<Text>();
		characters.ToList().ForEach(x => x.text = "");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// Triggers to flip character right if not already right
		if(Input.GetKeyDown(KeyCode.D) && !isCharFacingRight)
		{
			isCharFacingRight = true;
			FlipUI();
		}

		// Triggers to flip character left if not already left
		if(Input.GetKeyDown(KeyCode.A) && isCharFacingRight)
		{
			isCharFacingRight = false;
			FlipUI();
		}

		// Press E and be not talking to someone to initiate dialog
		if(pressEToInteract.IsActive() && !isTalking)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				InitiateDialogBox();
			}
		}

		// If we press any button while talking and the text is displaying still, it will speed it up
		// Otherwise, we revert back to our previous display speed
		if(inProcessOfDisplayingDialog && isTalking)
		{
			if(Input.anyKey)
			{
				timeToDisplay = 0.0f;
			}
			else
			{
				timeToDisplay = 0.055f;
			}
		}
		// If we are not in the process of displaying and still talking, once we press a button, it will
		// continue to the next piece of dialog
		else if(!inProcessOfDisplayingDialog && isTalking)
		{
			if(Input.anyKeyDown)
			{
				StartCoroutine(DisplayDialog(dialog[currDialogPos]));
			}
		}
		// Once we are done displaying and talking, then we can press a button and it will close the dialog
		else if(!inProcessOfDisplayingDialog && !isTalking)
		{
			if(Input.anyKeyDown && isAbleToTalk)
			{
				ExitDialog();
				pressEToInteract.enabled = true;
			}
		}

		// Press Esc if you are not talking to someone important to cancel dialog
		if(Input.GetKeyDown(KeyCode.Escape) && !importantDialog && isAbleToTalk)
		{
			ExitDialog();
			pressEToInteract.enabled = true;
		}
	}

	#region Dialog Logic
	/// <summary>
	/// Initiates the dialog box.
	/// If the character we are talking to is not null, then we set ourselves talking to them, set out dialog box
	/// to true, then if our dialogs are not null then we generate a random dialog from the character and display it.
	/// Otherwise we give the character three dots.
	/// </summary>
	public void InitiateDialogBox()
	{
		if(otherChar != null)
		{
			isTalking = true;
			pressEToInteract.enabled = false;

			dialogBox.SetActive(true);

			var otherCharDialog = otherChar.GetComponent<DialogHolder>();

			if(otherCharDialog != null)
			{
				if(otherCharDialog.dialogs != null)
				{
					//var multipleDialogs = otherCharDialog.dialogs;
					//var randNumGen = Random.Range(0, multipleDialogs.Count);


					dialog = otherCharDialog.dialogs[otherCharDialog.currDialog].text.Split('\n');
					importantDialog = otherCharDialog.isImportant;

					// Instead of random text, we'll progress through their dialog texts
					otherCharDialog.currDialog = (otherCharDialog.currDialog + 1) % otherCharDialog.dialogs.Count;
				}
				else
				{
					// TODO REWORK
					dialog = new string[1] { "{Character}: ..." };
				}
			}
			else
			{
				// TODO REWORK
				dialog = new string[1] { "{Character}: ..." };
			}
		}
	}

	/// <summary>
	/// Creates the character list after initialzing everything back to null.
	/// </summary>
	/// <param name="dialog">Dialog.</param>
	public static IEnumerator DisplayDialog(string dialogText)
	{
		inProcessOfDisplayingDialog = true;

		characters.ToList().ForEach(x => x.text = "");

		for(int i = 0; i < dialogText.Length; ++i)
		{
			characters[i].text = dialogText[i].ToString();
			yield return new WaitForSeconds(timeToDisplay);
		}

		ResetDialogVariables();

		if(currDialogPos < dialog.Length - 1)
		{
			++currDialogPos;
		}
		else
		{
			isTalking = false;
		}
	}

	/// <summary>
	/// Finds the string in list and returns the start and end index.
	/// </summary>
	/// <returns>The string in list.</returns>
	/// <param name="chars">Chars.</param>
	/// <param name="toFind">To find.</param>
	public static int[] FindStringInList(List<string> chars, string toFind)
	{
		var start_end_indexes = new int[2] { -1, -1 };

		for(int i = 0; i < chars.Count; ++i)
		{
			if(chars[i].Equals(toFind.Substring(0, 1)) && (i + (toFind.Length - 1)) < chars.Count)
			{
				bool isIncorrect = false;
				// We've already checked that the first index is found
				for(int j = 1; j < toFind.Length; ++j)
				{
					if(!chars[i + j].Equals(toFind.Substring(j, 1)))
					{
						isIncorrect = true;
						break;
					}
				}

				if(!isIncorrect)
				{
					start_end_indexes[0] = i;
					start_end_indexes[1] = i + (toFind.Length - 1);
					break;
				}
			}
		}

		return start_end_indexes;
	}

	/// <summary>
	/// Moves the text wave.
	/// </summary>
	/// <param name="indexStartAffect">Index of list characters to start affect.</param>
	/// <param name="indexEndAffect">Index of list characters to end affect.</param>
	/// <param name="height">Height of the wave.</param>
	public static void MoveText_Wave(int indexStartAffect, int indexEndAffect, float height)
	{
		
	}

	public static IEnumerator Wave(Text element, float height)
	{
		return null;
	}

	/*/// <summary>
	/// Displays the dialog.
	/// We display the dialog character by character waiting for specific amount of time. 
	/// If we are still currently in our current dialog, then we will continue displaying its next character.
	/// Otherwise, we reset the variables and test if we are done with the character full dialog or not
	/// </summary>
	/// <returns>The dialog.</returns>
	/// <param name="nextDialog">Next dialog.</param>
	public void DisplayDialog(string nextDialog)
	{
		StartCoroutine(DisplayDio(nextDialog));
				
		inProcessOfDisplayingDialog = true;

		/*if(currDialogText != nextDialog)
		{
			currDialogText = nextDialog;
			dialogText.text = "";
		}

		dialogText.text += nextDialog[currPosInString];

		yield return new WaitForSeconds(timeToDisplay);
		if(currPosInString < nextDialog.Length - 1)
		{
			++currPosInString;
			StartCoroutine(DisplayDialog(nextDialog));
		}
		else
		{
			//ResetDialogVariables();

		if(currDialogPos < dialog.Length - 1)
		{
			++currDialogPos;
		}
		else
		{
			isTalking = false;
		}
		//}
	}*/

	/// <summary>
	/// Resets the dialog variables.
	/// </summary>
	public static void ResetDialogVariables()
	{
		inProcessOfDisplayingDialog = false;
		timeToDisplay = 0.065f;
		//currPosInString = 0;
	}

	/// <summary>
	/// Exits the dialog and resets the dialog variables.
	/// </summary>
	public void ExitDialog()
	{
		isTalking = false;
		dialogBox.SetActive(false);

		ResetDialogVariables();
		currDialogPos = 0;
		//dialogText.text = "";

		StopAllCoroutines();
	}
	#endregion


	#region UI Manipulation
	//TODO Temporary Fix for the E button UI - Switch this to a characterManager

	/// <summary>
	/// Flips the UI based on which way the character is facing.
	/// </summary>
	public void FlipUI()
	{
		float t = 1;
		if(!isCharFacingRight)
		{
			t = -1;
		}

		pressEToInteract.rectTransform.localScale = new Vector3(t, 1, 1);
	}

	/// <summary>
	/// Swaps the player image positions.
	/// </summary>
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
	#endregion


	#region Trigger Events
	/// <summary>
	/// Raises the trigger enter 2d event.
	/// Allows the player to interact with E to start talking with the npc.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "npc")
		{
			// TODO Initiate talk sequence on button press, based on character name and some other variable maybe? Level Name?
			otherChar = col.gameObject;

			pressEToInteract.enabled = true;
			var charPos = col.gameObject.transform.FindChild("Head").transform.position;
			otherCharCamera.transform.position = new Vector3(charPos.x, charPos.y, -1);
			SwapPlayerImagePositions();

			isAbleToTalk = true;
		}

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "npc")
		{
			if(!isTalking)
			{
				pressEToInteract.enabled = true;
			}
		}
	}

	/// <summary>
	/// Raises the trigger exit 2d event.
	/// Once we leave the trigger area, we can no longer talk to the npc.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "npc")
		{
			otherChar = null;
			// TODO Deactivate initiation
			pressEToInteract.enabled = false;

			ExitDialog();

			isAbleToTalk = false;
		}

	}
	#endregion
}
