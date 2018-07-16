using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

	protected bool IsMoved, DoneToSpawn, OnPlace;
	protected Vector3 Target;
	[SerializeField]
	protected GameObject AllBlocks,Player,CurBlock;
	[SerializeField]
	protected float Pos = -1.55f;
	// Use this for initialization
	void Start () {
		Target = new Vector3 (-2.8f,-1.5f,3f);
	}

	// Update is called once per frame
	void Update () {
		
		if(Player)
		if(CurBlock.GetComponent<DetectCliks> ())
		if(!CurBlock.GetComponent<DetectCliks> ().GetStickInst())
		if (Player.GetComponent<MovePlayer> ().GetIsWin ())
		{
			if (!OnPlace)
			{
				if ((CurBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.x + CurBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.localScale.x / 2 > Pos))
				{
					DoneToSpawn = false;
					AllBlocks.transform.Translate (new Vector3 (-0.05f, 0f, 0f));
					Player.transform.Translate (new Vector3 (-0.05f, 0f, 0f));
					IsMoved = true;
				} else {
					//AllBlocks.transform.position
					//CurBlock.GetComponent<SpawnBlock> ().GetblockInstNext().transform.position = new Vector3 (Pos, CurBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.y
					//, CurBlock.GetComponent<SpawnBlock> ().GetblockInstNext ().transform.position.z);
					IsMoved = false;
					DoneToSpawn = true;
					Player.GetComponent<MovePlayer> ().SetIsReadyToSpawn (true);
					OnPlace = true;
				}
			}
		}
	}

	public  bool GetIsMoved()
	{
		return IsMoved;
	}
	public  bool GetDoneToSpawn()
	{
		return DoneToSpawn;
	}
	public  void SetDoneToSpawn(bool value)
	{
		 DoneToSpawn = value;
	}
	public  bool GetOnPlace()
	{
		return DoneToSpawn;
	}
	public  void SetOnPlace(bool value)
	{
		OnPlace = value;
	}
}
