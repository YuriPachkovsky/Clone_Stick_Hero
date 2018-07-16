using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlock : MonoBehaviour {


	protected GameObject blockInst, blockInstNext;
	protected bool OnPlace = false, isSpawn = false;
	[SerializeField]
	protected GameObject Block, AllBlocks,Player , detect;
	protected Vector3 BlockPosition;
	protected int CountSpawnBlock=-1;

	// Use this for initialization
	void Start () {
		SpawnBl ();
		blockInst = blockInstNext;
	}


	// Update is called once per frame
	void Update () {

		if(!AllBlocks.GetComponent<MoveBlocks> ().GetIsMoved ())
		if (blockInstNext.transform.position != BlockPosition && OnPlace == false) 
		{
			blockInstNext.transform.position = Vector3.MoveTowards (blockInstNext.transform.position, BlockPosition, Time.deltaTime * 3);
		}
		if (blockInstNext.transform.position == BlockPosition)
			OnPlace = true;
		

		if(Player)
		if(AllBlocks.GetComponent<MoveBlocks> ().GetDoneToSpawn() )
		if (Player.GetComponent<MovePlayer> ().GetIsWin () && !AllBlocks.GetComponent<MoveBlocks> ().GetIsMoved () && isSpawn == false && Player.GetComponent<MovePlayer> ().GetIsReadyToSpawn ())
		{
			blockInst = blockInstNext;
			SpawnBl ();
			OnPlace = false;
			isSpawn = true;
			AllBlocks.GetComponent<MoveBlocks> ().SetDoneToSpawn (false);
			Player.GetComponent<MovePlayer> ().SetIsReadyToSpawn (false);
		}
	}

	public Vector3 GetBlockPosition()
	{
		return BlockPosition;
	}

	public GameObject GetBlockInst()
	{
		return blockInst;
	}
	public GameObject GetblockInstNext()
	{
		return blockInstNext;
	}

	public bool GetIsSpawn()
	{
		return isSpawn;
	}

	public void SetIsSpawn(bool value)
	{
		isSpawn = value;
	}
	public bool GetOnPlace()
	{
		return OnPlace;
	}
	public void SetCountSpawnBlock(int value)
	{
		CountSpawnBlock = value;
	}
	public int GetCountSpawnBlock()
	{
		return CountSpawnBlock;
	}




	public void SpawnBl()
	{
		BlockPosition = new Vector3 (Random.Range (-0.2f, 1.64f), -1.5f, -8f);
		blockInstNext = Instantiate (Block,new Vector3(3f,-3f,-8f),Quaternion.identity) as GameObject;
		blockInstNext.transform.localScale = new Vector3 (Random.Range(0.2f,1.5f),2,1);
		blockInstNext.transform.parent = AllBlocks.transform;
		blockInstNext.AddComponent<xScore> ().SetScore(detect);
		CountSpawnBlock++;
	}
}
