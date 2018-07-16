using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	void OnMouseDown()
	{
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}
	void OnMouseUp()
	{
		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
	}
	void OnMouseUpAsButton()
	{
		switch (gameObject.name) 
		{
		case "retry":
			SceneManager.LoadScene ("main");
			break;
		}
	}
}
