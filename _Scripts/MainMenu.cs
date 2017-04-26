using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

	#region Scene Variables
	public Text NewGameText;
	public Text NewGameText_Alt;
	public Text LoadGameText;
	public Text LoadGameText_Alt;
	public Text SettingsText;
	public Text SettingsText_Alt;
	public Text QuitGameText;
	public Text QuitGameText_Alt;
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

	public void NewGame()
	{
		// TODO 
	}

	public void LoadGame()
	{
		// TODO
	}

	public void Settings()
	{
		// TODO
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
