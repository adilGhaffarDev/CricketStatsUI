using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Runs 
{
	[SerializeField]
	int value = 0;

	[Range(1,8)]
	[SerializeField]
	int runZone;

	[Range(1,10)]
	[SerializeField]
	float runLength;

	GameObject line;

	public void SetLine(GameObject l)
	{
		line = l;
	}

	public void EnableLine()
	{
		line.SetActive(true);
	}

	public void DisableLine()
	{
		line.SetActive(false);
	}

	public int GetValue()
	{
		return value;
	}

	public float GetLength()
	{
		return runLength;
	}

	public int GetZone()
	{
		return runZone;
	}
}
