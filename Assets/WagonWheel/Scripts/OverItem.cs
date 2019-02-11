using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverItem : MonoBehaviour 
{
	[SerializeField]
	Text overNo;
	[SerializeField]
	Text ones;
	[SerializeField]
	Text twos;
	[SerializeField]
	Text threes;
	[SerializeField]
	Text fours;
	[SerializeField]
	Text fives;
	[SerializeField]
	Text sixes;
	[SerializeField]
	Text total;

	//count array of 1s,2s,3s,4s,5s and 6s
	int[] RunsCount = new int[]{0,0,0,0,0,0};

	int totalCount;

	public void ShowSelf(Over os,int overNum)
	{
		overNo.text = (overNum+1).ToString();
		List<Runs> AllBalls = os.getPlayedBalls();
		if(AllBalls != null)
		{
			for(int i=0; i<AllBalls.Count;i++)
			{
				// increase run count
				RunsCount[AllBalls[i].GetValue()-1]++;
			}
			ones.text = RunsCount[0].ToString();
			twos.text = RunsCount[1].ToString();
			threes.text = RunsCount[2].ToString();
			fours.text = RunsCount[3].ToString();
			fives.text = RunsCount[4].ToString();
			sixes.text = RunsCount[5].ToString();
		}
		totalCount = (RunsCount[0]+(RunsCount[1]*2)+(RunsCount[2]*3)+(RunsCount[3]*4)+(RunsCount[4]*5)+(RunsCount[5]*6));
		total.text = totalCount.ToString();
		gameObject.SetActive(true);
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one, "easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.none, "time", 0.1f));
	}

}
