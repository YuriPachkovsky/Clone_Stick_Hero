using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	[SerializeField]
	protected GameObject Player, DetectsClick, SpawnBlock, Stick , Allblock;
	[SerializeField]
	protected AudioClip Clip_done, Clip_Lose;
	protected bool IsReady, IsWin, IsReadyToDown, IsReadyToSpawn;
	protected Vector3 Pos; 
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		if (Stick.GetComponent<DetectCliks> ())
		{
			if (!IsReady && DetectsClick.GetComponent<DetectCliks> ().GetStickReadyToCheck ()) 
			{
				DetectsClick.GetComponent<DetectCliks> ().SetStickReadyToCheck (false);
				if ((Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.localScale.y / 2 < SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x
				    - SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.localScale.x / 2 - Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.position.x)
				    || (Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.localScale.y / 2 > SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x
				    + SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.localScale.x / 2 - Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.position.x)) 
				{
					IsWin = false;
					AudioSource.PlayClipAtPoint (Clip_Lose, new Vector3 (0f, 0f, 0f));
				}
				else
				{
					IsWin = true;
					AudioSource.PlayClipAtPoint (Clip_done, new Vector3 (0f, 0f, 0f));
					DetectsClick.GetComponent<SpawnBlock> ().SetIsSpawn (false);
				}
			}
		}

		if (Player.transform.position.y < -6f)
			Destroy (Player);
		if (IsWin && Player) {
			
			if (SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x != Player.transform.position.x)
			{
				if (DetectsClick.GetComponent<DetectCliks> ().GetPlayerIsReady () == true)
					Player.transform.position = Vector3.MoveTowards (Player.transform.position,
						new Vector3 (SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x, -0.25f, -8f), Time.deltaTime * 3);
			}
		
			if (SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x <= Player.transform.position.x)
			{
				IsReady = true;
				Player.transform.position = (new Vector3 (SpawnBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x, -0.25f, -8f));
				Allblock.GetComponent<MoveBlocks> ().SetOnPlace (false);
				enabled = false;
			}
		
		} 
		else 
		{
				if (IsReadyToDown == false && (Player.transform.position != new Vector3 (Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.position.x
				   + Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.localScale.y / 2, -0.25f, -8f) && IsReadyToDown == false))
					Player.transform.position = Vector3.MoveTowards (Player.transform.position,
						new Vector3 (Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.position.x
						+ Stick.GetComponent<DetectCliks> ().GetStickInst ().transform.localScale.y / 2, -0.25f, -8f), Time.deltaTime * 3);
				else {
				// audio proigr
					IsReadyToDown = true;
					IsReady = true;
					Player.GetComponent<MovePlayer> ().SetIsWin (false);
					Player.transform.Translate (new Vector3 (0f, -8f, 0f) * Time.deltaTime);
				}
		}
	}

	public bool GetIsReady()
	{
		return IsReady;
	}

	public void SetIsReady(bool value)
	{
		IsReady = value;
	}

	public bool GetIsWin ()
	{
		return IsWin;
	}

	public void SetIsWin(bool value)
	{
		IsWin = value;
	}

	public bool GetIsReadyToSpawn ()
	{
		return IsReadyToSpawn;
	}

	public void SetIsReadyToSpawn(bool value)
	{
		IsReadyToSpawn = value;
	}
		
}
