using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TextDisplayManager : MonoBehaviour {

	/*public static Text[] characters;

	void Awake()
	{
		characters = GameObject.Find("TextHolder").GetComponentsInChildren<Text>();
		characters.ToList().ForEach(x => x.text = "");
	}

	/// <summary>
	/// Creates the character list after initialzing everything back to null.
	/// </summary>
	/// <param name="dialog">Dialog.</param>
	public static IEnumerator CreateCharacterList(string dialogText, )
	{
		characters.ToList().ForEach(x => x.text = "");

		for(int i = 0; i < dialogText.Length; ++i)
		{
			characters[i].text = dialogText[i].ToString();
			yield return new WaitForSeconds(0.065f);
		}

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
	}*/
}
