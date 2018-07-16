using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPlayer : MonoBehaviour {

	[SerializeField]
	protected GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position != new Vector3(-1.8f,-0.25f,-8f))
			Player.transform.position = Vector3.MoveTowards (Player.transform.position,
				new Vector3(-1.8f,-0.25f,-8f), Time.deltaTime * 4.25f);
		if (Player.transform.position == new Vector3 (-1.8f, -0.25f, -8f))
			enabled = false;
	}
}
