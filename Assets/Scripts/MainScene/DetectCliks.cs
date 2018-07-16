using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCliks : MonoBehaviour {

	[SerializeField]
	protected GameObject isStart,Stick,Player;
	protected GameObject StickInst;
	protected Vector3 StartPosToRotate;
	protected bool StickIsUp, StickIsRotate, PlayerIsReady, StickReadyToCheck;

	void start()
	{
		
	}

	void OnMouseDown ()
	{
		if (Player) 
		if (isStart.GetComponent<PlayGame> ().GameIsStart() == true)
		{
			if (StickInst == null)
			StickInst = Instantiate (Stick,new Vector3(-1.53f,-0.3f, -8f),Quaternion.identity) as GameObject;
			StickReadyToCheck = false;
			StickIsUp = true;
		}
	}

	void OnMouseUp ()
	{
		if (Player) 
		if (StickInst != null)
		{
			StickIsUp = false;
			PlayerIsReady = false;
			StickIsRotate = true;
			StartPosToRotate = new Vector3(StickInst.transform.position.x,StickInst.transform.position.y,
				StickInst.transform.position.z);
			StickReadyToCheck = true;
		}
	}

	void FixedUpdate()
	{
		if (Player) 
		{
			if (StickIsUp == true && StickIsRotate == false && Player.GetComponent<MovePlayer> ().GetIsReady () == false) {
				StickInst.transform.localScale += new Vector3 (0f, 1.8f * Time.deltaTime, 0f);
				StickInst.transform.localPosition += new Vector3 (0f, 0.9f * Time.deltaTime, 0f);
			}
			if (StickIsRotate == true && StickIsUp == false && Player.GetComponent<MovePlayer> ().GetIsReady () == false) {
				if (StickInst.transform.rotation.z > -0.7f) {
					StickInst.transform.RotateAround (new Vector3 (StartPosToRotate.x, StartPosToRotate.y - StickInst.transform.localScale.y / 2f, StartPosToRotate.z)
					, Vector3.forward, -Time.deltaTime * 500);
				}
				if (StickInst.transform.rotation.z < -0.7f) {
					StickIsRotate = false;
					PlayerIsReady = true;
					StickInst.transform.rotation = Quaternion.Euler (new Vector3 (StickInst.transform.rotation.x, StickInst.transform.rotation.y, -90f));
					Player.GetComponent<MovePlayer> ().enabled = true;
				}
			}
			if (Player && Player.GetComponent<MovePlayer> ().GetIsReady () == true) {
				Player.GetComponent<MovePlayer> ().SetIsReady (false);
				Destroy (StickInst);
			}
		}
	}

	public bool GetPlayerIsReady()
	{
		return PlayerIsReady;
	}

	public GameObject GetStickInst()
	{
		return StickInst;
	}
	public bool GetStickIsUp()
	{
		return StickIsUp;
	}

	public bool GetStickIsRotate()
	{
		return StickIsRotate;	
	}
	public bool GetStickReadyToCheck()
	{
		return StickReadyToCheck;
	}
	public void SetStickReadyToCheck(bool value)
	{
		StickReadyToCheck = value;
	}
}
