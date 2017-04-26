using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManipulation : MonoBehaviour {

	#region TextManipulation Variables
	public Text text;
	public Text altText;
	public bool hovering;
	public bool finishedMoving = true;
	public Vector3 textInitPos;
	public Vector3 textFinalPos;
	public Vector3 altTextInitPos;
	public Vector3 altTextFinalPos;
	float elapsedTime;
	#endregion

	void Awake()
	{
		//text = transform.FindChild("Text").GetComponent<Text>();
		//altText = transform.FindChild("Text_Alt").GetComponent<Text>();

		textInitPos = text.transform.position;
		altTextInitPos = altText.rectTransform.position;

		textFinalPos = altTextInitPos;
		altTextFinalPos = textInitPos;
	}

	void Update()
	{
		if(hovering)
		{
			if(!finishedMoving)
			{
				elapsedTime += Time.deltaTime;
				MoveText_Forward();
			}
			else
			{
				ManipulateText(altText);
			}
		}
		else if(!finishedMoving)
		{
			MoveText_Back();
		}
	}

	public void ManipulateText(Text altCurrText)
	{
		
	}

	public void MoveText_Forward()
	{
		if(Mathf.Abs(text.transform.position.x - altTextInitPos.x) >= 0.1f)
		{
			text.transform.position = Vector3.Lerp(text.transform.position, altTextInitPos, elapsedTime);
			altText.transform.position = Vector3.Lerp(altText.transform.position, textInitPos, elapsedTime);

			text.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(text.GetComponent<CanvasGroup>().alpha, 0, elapsedTime);
			altText.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(altText.GetComponent<CanvasGroup>().alpha, 1, elapsedTime);
		}
		else
		{
			finishedMoving = true;
			elapsedTime = 0.0f;
		}
	}

	public void MoveText_Back()
	{
		if(Mathf.Abs(text.transform.position.x - altTextFinalPos.x) >= 0.1f)
		{
			text.transform.position = Vector3.Lerp(text.transform.position, altTextFinalPos, elapsedTime);
			altText.transform.position = Vector3.Lerp(altText.transform.position, textFinalPos, elapsedTime);

			text.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(text.GetComponent<CanvasGroup>().alpha, 1, elapsedTime);
			altText.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(altText.GetComponent<CanvasGroup>().alpha, 0, elapsedTime);
		}
		else
		{
			finishedMoving = true;
			elapsedTime = 0.0f;
		}
	}
}
