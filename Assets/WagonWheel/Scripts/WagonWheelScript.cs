using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WagonWheelScript : MonoBehaviour 
{
	[SerializeField]
	WagonWheelDat Data;

	[SerializeField]
	OversTable OversTab;

	[SerializeField]
	Transform Wheel;

	[SerializeField]
	List<Color> ShotColors;

	[SerializeField]
	List<ToggleScript> RunButtons;

	[SerializeField]
	GameObject ShotImg;

	[SerializeField]
	Text TotalOversTxt;

	[SerializeField]
	Text TotalOnesTxt;
	[SerializeField]
	Text TotalTwosTxt;
	[SerializeField]
	Text TotalThreesTxt;
	[SerializeField]
	Text TotalFoursTxt;
	[SerializeField]
	Text TotalFivesTxt;
	[SerializeField]
	Text TotalSixesTxt;
	[SerializeField]
	Text TotalRunsTxt;

	[SerializeField]
	Transform BotPan;

	[SerializeField]
	Transform TablePos;

	[SerializeField]
	Transform BotPanPos;

	[SerializeField]
	Transform GroundPos;

	//count array of 1s,2s,3s,4s,5s and 6s
	int[] RunsCount = new int[]{0,0,0,0,0,0};

	int totalRuns;

	void Start () 
	{
		StartCoroutine("ShowGraphAnim");
	}

	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
	{
		GameObject shotLine = new GameObject();
		shotLine.transform.position = start;
		shotLine.AddComponent<LineRenderer>();
		LineRenderer lr = shotLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(5f, 10f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
	}

	IEnumerator ShowGraphAnim()
	{
		iTween.MoveTo(OversTab.gameObject, iTween.Hash("position", TablePos.position, "easeType", iTween.EaseType.easeOutSine, "loopType", iTween.LoopType.none, "time", 1f));
		iTween.MoveTo(BotPan.gameObject, iTween.Hash("position", BotPanPos.position, "easeType", iTween.EaseType.easeOutSine, "loopType", iTween.LoopType.none, "time", 1f));

		iTween.MoveTo(Wheel.gameObject, iTween.Hash("position", GroundPos.position, "easeType", iTween.EaseType.easeOutSine, "loopType", iTween.LoopType.none, "time", 1f));

		yield return new WaitForSeconds(1f);

		iTween.RotateTo(Wheel.gameObject,iTween.Hash("rotation",GroundPos.eulerAngles, "easeType",iTween.EaseType.easeInOutSine,"time",0.5f));

		List<Over> AllOvers = Data.getOvers();
		TotalOversTxt.text = AllOvers.Count.ToString();

		for(int i=0; i < AllOvers.Count; i++)
		{
			OversTab.AddOverItem(AllOvers[i],i);
			List<Runs> AllBalls = AllOvers[i].getPlayedBalls();

			for(int j = 0; j < AllBalls.Count; j++)
			{
				drawBallLine(AllBalls[j]);

			}
			yield return new WaitForSeconds(0.1f);

		}

		totalRuns = (RunsCount[0]+(RunsCount[1]*2)+(RunsCount[3]*3)+(RunsCount[3]*4)+(RunsCount[4]*5)+(RunsCount[5]*6));
		TotalRunsTxt.text = totalRuns.ToString();
		TotalOnesTxt.text = RunsCount[0].ToString();
		TotalTwosTxt.text = RunsCount[1].ToString();
		TotalThreesTxt.text = RunsCount[2].ToString();
		TotalFoursTxt.text = RunsCount[3].ToString();
		TotalFivesTxt.text = RunsCount[4].ToString();
		TotalSixesTxt.text = RunsCount[5].ToString();
	}

	void drawBallLine(Runs ballRun)
	{
		// increase run count
		RunsCount[ballRun.GetValue()-1]++;

		float length = ballRun.GetLength()/10;
		int zone = ballRun.GetZone();
			
		GameObject shotline = Instantiate(ShotImg) as GameObject;
		shotline.transform.SetParent(Wheel.transform);
		shotline.transform.localPosition = Vector3.zero;

		ballRun.SetLine(shotline);
	
		//random angle for the give zone
		float angle = 45 * zone;
		angle = Random.Range((angle-45)+5,angle-5);
		//random angle for the give zone
		shotline.transform.localEulerAngles = new Vector3(0,0,angle);
		shotline.GetComponent<Image>().fillAmount = length;
		shotline.GetComponent<Image>().color = ShotColors[ballRun.GetValue()-1];
	}

	public void OnRunButton(int btnNo)
	{
		List<Over> AllOvers = Data.getOvers();

		if(btnNo == 7)
		{
			for(int i=0 ;i<RunButtons.Count;i++)
			{
				RunButtons[i].turnOn();
			}
			for(int i=0; i < AllOvers.Count; i++)
			{
				List<Runs> AllBalls = AllOvers[i].getPlayedBalls();
				for(int j = 0; j < AllBalls.Count; j++)
				{
					AllBalls[j].EnableLine();
				}
			}
			return;
		}

		for(int i=0 ;i<RunButtons.Count;i++)
		{
			RunButtons[i].turnOff();
		}
		RunButtons[btnNo-1].turnOn();


		for(int i=0; i < AllOvers.Count; i++)
		{
			List<Runs> AllBalls = AllOvers[i].getPlayedBalls();
			for(int j = 0; j < AllBalls.Count; j++)
			{
				if(AllBalls[j].GetValue() != btnNo)
				{
					AllBalls[j].DisableLine();
				}
				else
				{
					AllBalls[j].EnableLine();
				}
			}
		}
	}
}
