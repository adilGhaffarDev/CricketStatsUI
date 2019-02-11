using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour 
{
	[SerializeField]
	Transform tick;

	void Start()
	{
		turnOn();
	}

	public void turnOn()
	{
		tick.gameObject.SetActive(false);
	}

	public void turnOff()
	{
		tick.gameObject.SetActive(true);
	}

	public bool checkOn()
	{
		return tick.gameObject.activeSelf;
	} 
}
