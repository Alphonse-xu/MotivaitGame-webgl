using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opencloseDoor: MonoBehaviour {

	public Animator openandclose;
	public bool open;
	public GameObject propManager;
	private bool keyState;
	private Text lackText;

	private void Awake()
	{
		openandclose = gameObject.GetComponent<Animator>();
		open = false;
		propManager = GameObject.Find("PropManager");
		lackText = GameObject.Find("LackText").GetComponent<Text>();
		keyState = false;
	}

	void OnTouch ()
	{
		
			if (!keyState)
			{
				foreach (Transform key in propManager.GetComponentsInChildren<Transform>(true))
				{
					if (key.gameObject.CompareTag(gameObject.tag) && key.gameObject.activeSelf)
					{
						keyState = true;
						DoorPlay();
					}
					else
					{
						lackText.text = "Lack " + gameObject.tag;
					}
				}
			}
			else
			{
				DoorPlay();
			}

		
	}

	void DoorPlay()
	{
		if (open == false) 
			StartCoroutine (opening ());
		else 
			StartCoroutine (closing ());
	}

	IEnumerator opening(){
		print ("you are opening the door");
		openandclose.Play ("Opening");
		open = true;
		yield return new WaitForSeconds (0.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
		openandclose.Play ("Closing");
		open = false;
		yield return new WaitForSeconds (0.5f);
	}


}

