using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

	#region Text Variables
	public Text NewGameText;
	public Text NewGameText_Alt;
	public Text LoadGameText;
	public Text LoadGameText_Alt;
	public Text SettingsText;
	public Text SettingsText_Alt;
	public Text QuitGameText;
	public Text QuitGameText_Alt;
	#endregion

	#region Transition Logic
	public CanvasGroup MenuButtons;
	public CanvasGroup StartGameOptions;
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void PointerEnter(Button button)
	{
		button.GetComponent<TextManipulation>().hovering = true;
		button.GetComponent<TextManipulation>().finishedMoving = false;
		button.GetComponent<TextManipulation>().MoveText_Forward();
	}

	public void PointerExit(Button button)
	{
		button.GetComponent<TextManipulation>().hovering = false;
		button.GetComponent<TextManipulation>().finishedMoving = false;
		button.GetComponent<TextManipulation>().MoveText_Back();
	}

	public void StartGame()
	{
		// TODO
		MenuButtons.alpha = 0;
		MenuButtons.interactable = false;
		MenuButtons.blocksRaycasts = false;

		StartGameOptions.alpha = 1;
		StartGameOptions.interactable = true;
		StartGameOptions.blocksRaycasts = true;
	}

	public void LoadGame(Button button)
	{
		// TODO
	}

	public void Settings()
	{
		// TODO
	}

	public void Back()
	{
		MenuButtons.alpha = 1;
		MenuButtons.interactable = true;
		MenuButtons.blocksRaycasts = true;

		StartGameOptions.alpha = 0;
		StartGameOptions.interactable = false;
		StartGameOptions.blocksRaycasts = false;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
