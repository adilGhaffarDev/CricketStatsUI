using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ManhattonGraph : MonoBehaviour 
{
	[SerializeField]
	WagonWheelDat Data;

	[SerializeField]
	List<GraphBar> GraphBars;

	[SerializeField]
	Text TotalScoreTxt;

	[SerializeField]
	Text TotalOversTxt;

	[SerializeField]
	Transform BarsParent;

	[SerializeField]
	GameObject BarPrefab;

	[SerializeField]
	Transform GraphMan;

	[SerializeField]
	Transform BotBar;

	[SerializeField]
	Transform GraphPos;

	[SerializeField]
	Transform BotBarPos;


	int totalScore = 0;

	void Start () 
	{
		GraphBars = new List<GraphBar>();

	}

	public void ShowGraph(Dictionary<int,int> runsbyOvers)
	{
		//Data = dat;
		StartCoroutine(ShowGraphInnings(runsbyOvers));
	}

	IEnumerator ShowGraphInnings(Dictionary<int,int> runsbyOvers)
	{
		iTween.MoveTo(GraphMan.gameObject, iTween.Hash("position", GraphPos.position, "easeType", iTween.EaseType.easeOutSine, "loopType", iTween.LoopType.none, "time", 1f));
		iTween.MoveTo(BotBar.gameObject, iTween.Hash("position", BotBarPos.position, "easeType", iTween.EaseType.easeOutSine, "loopType", iTween.LoopType.none, "time", 1f));

		yield return new WaitForSeconds(1f);
		int initialBars = GraphBars.Count;

		totalScore = 0;

		TotalOversTxt.text = runsbyOvers.Count.ToString();
		int currOverScore = 0;

		for(int i=0; i < runsbyOvers.Count; i++)
		{
			if(runsbyOvers.TryGetValue(i,out currOverScore))
			{
				if(initialBars == 0)
				{
					GameObject bar = Instantiate(BarPrefab) as GameObject;
					bar.transform.SetParent(BarsParent);
					bar.transform.localScale = Vector3.one;
					bar.transform.localPosition = Vector3.zero;
					GraphBar BarGB = bar.GetComponent<GraphBar>();
					BarGB.ShowSelf(i,currOverScore);
					GraphBars.Add(BarGB);
				}
				else
				{
					GraphBars[i].ShowSelf(i,currOverScore);
					initialBars--;
				}
				totalScore += currOverScore;

			}
			else
			{
				//ShowBar(i,0);
			}
			//yield return new WaitForSeconds(0.1f);

		}

		for(int j = 0; j < GraphBars.Count; j++)
		{
			GraphBars[j].PlayAnimation();
		}

		TotalScoreTxt.text = totalScore.ToString();
	}

//	IEnumerator ShowGraph()
//	{
//		yield return new WaitForSeconds(0.1f);
//		totalScore = 0;
//		List<Over> AllOvers = Data.getOvers();
//		TotalOversTxt.text = AllOvers.Count.ToString();
//		int currOverScore = 0;
//	
//		for(int i=0; i < AllOvers.Count; i++)
//		{
//			List<Runs> AllBalls = AllOvers[i].getPlayedBalls();
//			currOverScore = 0;
//			for(int j = 0; j < AllBalls.Count; j++)
//			{
//				totalScore += AllBalls[i].GetValue();
//				currOverScore += AllBalls[i].GetValue();
//			}
//			ShowBar(i,currOverScore);
//			yield return new WaitForSeconds(0.1f);
//
//		}
//
//		TotalScoreTxt.text = totalScore.ToString();
//	}

//	void ShowBar(int overNo,int runs)
//	{
//		Debug.Log("runs : "+runs);
//		GraphBars[overNo].gameObject.SetActive(true);
//		GraphBars[overNo].fillAmount = ((float)runs/28.0f);
//	}
}
