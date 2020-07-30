using UnityEngine;
using UnityEngine.UI;

public class Whiteboard : MonoBehaviour
{
	private GameObject propManager;
	private GameObject num3;
	private Text lackText;

	public static bool powerFlag;

	private void Awake()
	{
		propManager = GameObject.Find("PropManager");
		lackText = GameObject.Find("LackText").GetComponent<Text>();
		num3 = transform.GetChild(3).gameObject;
		powerFlag = false;
	}
	void OnTouch()
	{
		if (!powerFlag)
		{
			lackText.text = "No power";
		}
		else
		{
			num3.SetActive(true);
		}
		
	}
}
