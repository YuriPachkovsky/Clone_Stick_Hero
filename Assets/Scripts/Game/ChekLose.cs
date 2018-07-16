using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChekLose : MonoBehaviour {

	[SerializeField]
	protected GameObject player;
	[SerializeField]
	protected Text text, curScore;
	protected RectTransform MyRec;
	protected bool IsActive;
	// Use this for initialization
	void Start () {
		MyRec = GetComponent<RectTransform> ();
		IsActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!player)
		if (!IsActive) {
			if (MyRec.offsetMin.y != 0f) {
				MyRec.offsetMin += new Vector2 (0, 2f);
				MyRec.offsetMax += new Vector2 (0, 2f);
			}
			if (MyRec.offsetMin.y >= 0f) {	
				IsActive = true;
				text.text = text.text + curScore.text;
				curScore.gameObject.SetActive (false);
				text.GetComponent<Text> ().enabled = true;
			}
		}
	}
}
