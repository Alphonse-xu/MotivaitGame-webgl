using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperInPrinter : MonoBehaviour
{
	private GameObject propManager;
	private Text lackText;
	private GameObject paper;

	private void Awake()
	{
		propManager = GameObject.Find("PropManager");
		lackText = GameObject.Find("LackText").GetComponent<Text>();
		paper = transform.GetChild(0).gameObject;
	}
	void OnTouch()
	{
		foreach (Transform key in propManager.GetComponentsInChildren<Transform>(true))
		{
			if (key.gameObject.CompareTag(gameObject.tag) && key.gameObject.activeSelf)
			{
				paper.SetActive(true);
				gameObject.layer = LayerMask.NameToLayer("Default");
			}
			else
			{
				lackText.text = "Lack " + gameObject.tag;
			}
		}
	}
}
