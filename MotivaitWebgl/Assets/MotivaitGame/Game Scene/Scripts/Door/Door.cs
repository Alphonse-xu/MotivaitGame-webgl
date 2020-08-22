using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// base class of two same door
/// </summary>

public class Door : MonoBehaviour
{
	public Animator openandclose;
	public bool open = false;

	protected void DoorPlay()
	{
		if (open == false)
			StartCoroutine(opening());
		else
			StartCoroutine(closing());
	}

	IEnumerator opening()
	{
		print("you are opening the door");
		openandclose.Play("Opening");
		open = true;
		yield return new WaitForSeconds(0.5f);
	}

	IEnumerator closing()
	{
		print("you are closing the door");
		openandclose.Play("Closing");
		open = false;
		yield return new WaitForSeconds(0.5f);
	}

}
