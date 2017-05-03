using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Vector3S {

	public float x { get; set; }
	public float y { get; set; }
	public float z { get; set; }

	public Vector3S(float aX, float aY, float aZ)
	{
		x = aX;
		y = aY;
		z = aZ;
	}

	public Vector3S(float aX, float aY)
	{
		x = aX;
		y = aY;
		z = 0.0f;
	}

	public Vector3S()
	{
		x = 0.0f;
		y = 0.0f;
		z = 0.0f;
	}

	public Vector3 ToVector3()
	{
		return new Vector3(x, y, z);
	}

	/*public void SavePointToVector3S(SavePoint aSavePoint)
	{
		x = aSavePoint.location.x;
		y = aSavePoint.location.y;
		z = aSavePoint.location.z;
	}*/

}
