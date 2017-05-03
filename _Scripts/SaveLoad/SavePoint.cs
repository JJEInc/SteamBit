using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavePoint : MonoBehaviour {

	public Vector3S location;
	public Light saveLight;
	public ParticleSystem saveParticles;
	public bool isSaveEnabled;
	
	void Awake()
	{
		location = new Vector3S(transform.position.x, transform.position.y);
	}

	void Update()
	{
		if(isSaveEnabled)
		{
			saveLight.intensity = Mathf.Lerp(saveLight.intensity, 1, Time.deltaTime);
		}
		else if(saveLight != null)
		{
			if(saveLight.intensity > 0.05f)
			{
				saveLight.intensity = Mathf.Lerp(saveLight.intensity, 0, Time.deltaTime);
			}
			else
			{
				saveLight.enabled = false;
			}
		}
	}

	#region Trigger Events
	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			isSaveEnabled = true;

			saveLight = gameObject.GetComponentInChildren<Light>();
			saveParticles = gameObject.GetComponentInChildren<ParticleSystem>();

			saveLight.enabled = true;
			saveParticles.Play();
		}

	}

	/// <summary>
	/// Raises the trigger exit 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			isSaveEnabled = false;

			//saveLight.enabled = false;
			saveParticles.Stop();
		}

	}
	#endregion
}
