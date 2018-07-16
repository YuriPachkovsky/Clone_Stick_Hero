using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayGame : MonoBehaviour {
	
	[SerializeField]
	protected Text Game_Name, Tap_to_Play;
	[SerializeField]
	protected GameObject Buttons, Spawn_Blocks , Score;
	protected bool IsStart;



	void OnMouseDown()
	{
		if (!IsStart)
		{
			IsStart = true;
			Tap_to_Play.gameObject.SetActive (false);
			Buttons.GetComponent<ScrollButtons> ().SetSpeed (-5f);
			Buttons.GetComponent<ScrollButtons> ().SetCheckPos (-150);
			Spawn_Blocks.GetComponent<SpawnBlock> ().enabled = true;
			Score.GetComponent<Score> ().enabled = true;
		}
	}
		
	public bool GameIsStart()
	{
		return IsStart;
	}
}
