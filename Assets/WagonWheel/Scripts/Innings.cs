using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Innings 
{
	[SerializeField]
	List<Over> overs;

	public List<Over> getOvers()
	{
		return overs;
	}
}
