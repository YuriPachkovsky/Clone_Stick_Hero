using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlock : MonoBehaviour {



	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag.Equals ("Block"))
		{
			Destroy (other.gameObject);
		}
	}
		
}
