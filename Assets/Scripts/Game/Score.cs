using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	[SerializeField]
	protected GameObject score;
	[SerializeField]
	protected Text Record;
	protected Text text;
	// Use this for initialization
	void Start ()
	{
		Record.gameObject.SetActive (true);
		Record.text = "Top: " + PlayerPrefs.GetInt ("Record").ToString ();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine (Wait ());
		text.text = score.GetComponent<SpawnBlock> ().GetCountSpawnBlock ().ToString ();
		if (PlayerPrefs.GetInt ("Record") < score.GetComponent<SpawnBlock> ().GetCountSpawnBlock ()) 
		{
			PlayerPrefs.SetInt( "Record" , score.GetComponent<SpawnBlock> ().GetCountSpawnBlock ());
			Record.text = "Top: " + PlayerPrefs.GetInt ("Record").ToString ();
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds (1);
	}
}
