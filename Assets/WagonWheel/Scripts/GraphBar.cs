using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphBar : MonoBehaviour 
{
	//[SerializeField]
	Image Bar;

	[SerializeField]
	Text OverNo;

	int _runs = 0;
	// Use this for initialization
//	void Start () 
//	{
//		Bar = GetComponent<Image>();
//	}
	
	public void ShowSelf(int overNo,int runs)
	{
		Debug.Log("runs : "+runs);
		Bar = GetComponent<Image>();
		gameObject.SetActive(true);
		_runs = runs;
		//Bar.fillAmount = ((float)runs/28.0f);
		OverNo.text = overNo.ToString();
	}

	public void PlayAnimation()
	{
		StartCoroutine("PlayBarAnim");
	}

	IEnumerator PlayBarAnim()
	{
		float totalToFill = ((float)_runs/28.0f);
		while(totalToFill > 0)
		{
			Bar.fillAmount += 0.01f;
			totalToFill -= 0.01f;
			yield return new WaitForSeconds(0.01f);

		}
	}
}
