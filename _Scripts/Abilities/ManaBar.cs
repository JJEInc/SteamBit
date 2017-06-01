using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {

	public static Slider manabar;
	public static Slider manaSubBar;
	public static bool abilityInUse;
	public static float cooldown = 2.5f;
	static float elapsedTime = cooldown;
	public static bool blinking;

	void Awake()
	{
		manabar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<Slider>();
		manaSubBar = GameObject.FindGameObjectWithTag("ManaSubBar").GetComponent<Slider>();

		manaSubBar.GetComponent<CanvasGroup>().alpha = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		if(elapsedTime < cooldown && !abilityInUse)
		{
			elapsedTime += Time.deltaTime;
		}

		if(manabar.value != manabar.maxValue)
		{
			if(elapsedTime >= cooldown && !abilityInUse)
			{
				Recover();
			}
		}

		if(manaSubBar.value <= 0.0f && !blinking && abilityInUse)
		{
			StartCoroutine(Blink(manaSubBar));
		}
		else if(!blinking || !abilityInUse)
		{
			blinking = false;
			StopAllCoroutines();
		}
	}

	public static bool Deplete(float value)
	{
		if(value <= manabar.value)
		{
			manabar.value -= value;
			elapsedTime = 0.0f;
			return true;
		}
		else
		{
			return false;
		}
	}

	public void Raise(float value)
	{
		manabar.value += value;
	}

	public void Recover()
	{
		manabar.value += 0.25f;
	}

	public IEnumerator Blink(Slider slider)
	{
		blinking = true;

		slider.GetComponent<CanvasGroup>().alpha = 0;
		yield return new WaitForSeconds(.2f);
		slider.GetComponent<CanvasGroup>().alpha = 1;
		yield return new WaitForSeconds(.5f);
		slider.GetComponent<CanvasGroup>().alpha = 0;
		yield return new WaitForSeconds(.2f);
		slider.GetComponent<CanvasGroup>().alpha = 1;
		yield return new WaitForSeconds(.5f);

		blinking = false;
	}
}
