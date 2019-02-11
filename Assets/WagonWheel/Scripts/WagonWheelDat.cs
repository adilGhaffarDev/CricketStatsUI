using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WagonWheelDat : ScriptableObject 
{
	[SerializeField]
	List<Over> overs;

	public List<Over> getOvers()
	{
		return overs;
	}
}
