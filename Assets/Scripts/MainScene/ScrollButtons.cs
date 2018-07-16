using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButtons : MonoBehaviour {

	[SerializeField]
	protected float Speed = 5f, CheckPos = 0f;

	protected RectTransform MyRec;


	void Start () 
	{
		MyRec = GetComponent<RectTransform> ();
	}
	

	void Update () 
	{
		if ( MyRec.offsetMin.y != CheckPos ) 
		{
			MyRec.offsetMin += new Vector2 (0, Speed);
			MyRec.offsetMax += new Vector2 (0, Speed);
		}
	}

	public float GetSpeed()
	{
		return Speed;
	}

	public void SetSpeed(float value)
	{
		Speed = value;
	}

	public float GetCheckPos()
	{
		return CheckPos;
	}

	public void SetCheckPos(float value)
	{
		CheckPos = value;
	}

}
