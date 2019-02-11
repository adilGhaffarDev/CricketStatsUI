using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Over 
{
	[SerializeField]
	List<Runs> playedBalls;

	public List<Runs> getPlayedBalls()
	{
		return playedBalls;
	}
}
