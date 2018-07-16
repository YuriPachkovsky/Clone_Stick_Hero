using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMainBlocks : MonoBehaviour {


	[SerializeField]
	protected float Speed = 5f, CheckPos = -0.5f;
	protected Transform MyTransform;


	void Start () 
	{
		MyTransform = GetComponent<Transform> ();
	}


	void Update () 
	{
		
		if ( MyTransform.position.y < CheckPos ) 
		{
			MyTransform.transform.Translate (new Vector3 (0,Speed,0)*Time.deltaTime);
		}
		if (MyTransform.position.y > CheckPos)
			MyTransform.transform.position = new Vector3 (MyTransform.position.x, CheckPos, MyTransform.position.z);	
	}
}
