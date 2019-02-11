using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OversTable : MonoBehaviour 
{
	[SerializeField]
	GameObject overItemPrefab;

	[SerializeField]
	GameObject content;

	public void AddOverItem(Over os,int overNum)
	{
		//content.GetComponent<Rect>().height += 
		RectTransform rt = content.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y + overItemPrefab.GetComponent<RectTransform>().sizeDelta.y);

		GameObject obj = Instantiate(overItemPrefab) as GameObject;
		obj.transform.SetParent(content.transform);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localEulerAngles = Vector3.zero;

		OverItem overIt = obj.GetComponent<OverItem>();
		overIt.ShowSelf(os,overNum);
		//overIt.transform.localScale = Vector3.one;
	}
}
