using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class xScore : MonoBehaviour {

	[SerializeField]
	protected GameObject Score;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Stick")) 
		{
			if (Score) 
				try{
				print("dqe");
				Score.GetComponent<SpawnBlock> ().SetCountSpawnBlock(Score.GetComponent<SpawnBlock> ().GetCountSpawnBlock()+1) ;
			}
			catch(System.Exception ex)
			{
				print("ex"+ ex.Message);
			}
		}
	}

	public void SetScore(GameObject value)
	{
		Score = value;
	}
}
