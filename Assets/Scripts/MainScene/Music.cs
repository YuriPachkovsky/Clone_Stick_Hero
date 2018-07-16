using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

	[SerializeField]
	protected Sprite Disable, Enable;
	[SerializeField]
	protected AudioListener myAudioListener;
	protected bool  enable = true,IsActive = false;

	Image image;

	void Start()
	{
		image = GetComponent<Image> ();
		image.sprite = Enable;
	}

	void OnMouseUpAsButton()
	{
		enable = !enable;
		IsActive = true;
	}

	void Update()
	{
		if(IsActive)
		{
			print ("4");
			IsActive = false;
			if (enable) 
			{
				AudioListener.volume = 1f;
				image.sprite = Enable;

			}
			else 
			{
				AudioListener.volume = 0f;
				image.sprite = Disable;
			}
		}
	}
}
