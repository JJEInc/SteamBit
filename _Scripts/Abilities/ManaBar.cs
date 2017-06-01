using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {

	public static Slider manabar;
	public static Slider manaSubBar;
	public static bool abilityInUse;
	public static float cooldown = 2.5f;
	public static bool blinking;
	static float elapsedTime = cooldown;
	static float recoverAmount = 0.25f;

	void Awake()
	{
		manabar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<Slider>();
		manaSubBar = GameObject.FindGameObjectWithTag("ManaSubBar").GetComponent<Slider>();

		manaSubBar.GetComponent<CanvasGroup>().alpha = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		// If our elapsed time is less than our cooldown and the ability is not in use then increase our elapsed time
		if(elapsedTime < cooldown && !abilityInUse)
		{
			elapsedTime += Time.deltaTime;
		}

		// If we are not at our max value then if we are not using an ability and our elapsed time is high enough, then we recover
		if(manabar.value != manabar.maxValue)
		{
			if(elapsedTime >= cooldown && !abilityInUse)
			{
				Recover();
			}
		}

		// If our manabar is less than zero and we aren't blinking and we are using our ability then we blink
		// else if we are not blinking or our ability is not in use, then we stop blinking
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

	/// <summary>
	/// Deplete the manabar the specified amount and reset our elapsed time.
	/// </summary>
	/// <param name="value">Value.</param>
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

	/// <summary>
	/// Raise the manabar the specified amount.
	/// </summary>
	/// <param name="value">Value.</param>
	public void Raise(float value)
	{
		manabar.value += value;
	}

	/// <summary>
	/// Recover at a steady rate the recover amount.
	/// </summary>
	public void Recover()
	{
		manabar.value += recoverAmount;
	}

	/// <summary>
	/// Blink the specified slider on and off.
	/// </summary>
	/// <param name="slider">Slider.</param>
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
