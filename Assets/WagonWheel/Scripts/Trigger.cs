using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ManhattonEvent : UnityEvent<Dictionary<int,int>>
{
	
}

public class Trigger : MonoBehaviour 
{
	[SerializeField]
	Innings ManahattonData;

	Dictionary<int,int> RunsByOver;
	
	[SerializeField]
	ManhattonEvent ShowManhattanGraph;
	// Use this for initialization
	void Start () 
	{
		RunsByOver = new Dictionary<int, int>();
		List<Over> AllOvers = ManahattonData.getOvers();
		int currOverScore = 0;

		for(int i=0; i < AllOvers.Count; i++)
		{
			List<Runs> AllBalls = AllOvers[i].getPlayedBalls();
			currOverScore = 0;
			for(int j = 0; j < AllBalls.Count; j++)
			{
				currOverScore += AllBalls[j].GetValue();
			}
			RunsByOver.Add(i,currOverScore);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown && ShowManhattanGraph != null)
		{
			ShowManhattanGraph.Invoke(RunsByOver);
		}
	}
}
