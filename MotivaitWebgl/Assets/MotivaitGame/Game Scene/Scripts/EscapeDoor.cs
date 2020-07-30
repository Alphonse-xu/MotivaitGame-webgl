using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeDoor : MonoBehaviour
{
	public Animator cameraMove;
	private GameObject propManager;
	private Text padNoticeText;
	private GameObject cameraScript;
	private GameObject playerScript;

	private bool runFlag;
	public static bool gameOverFlag;

	private void Awake()
	{
		cameraMove = gameObject.GetComponent<Animator>();
		padNoticeText = UIManager.Instance.keyPadPanel.transform.GetChild(1).gameObject.GetComponent <Text>();
		propManager = GameObject.Find("PropManager");
		playerScript = GameObject.Find("FPSPlayer");
		cameraScript = GameObject.Find("FPSPlayer/PlayerCamera");
		padNoticeText.text = "";

		runFlag = false;
		gameOverFlag = false;	}

	void OnTouch()
	{
		cameraMove.Play("LockLook");
		cameraScript.GetComponent<PlayerLook>().enabled = false; // unable playerlook
		playerScript.GetComponent<PlayerMove>().enabled = false;//unable playermove
		GameObject.Find("PlayerCamera").transform.Find("FocusCamera").GetComponent<ObserveObj>().enabled = false;

		runFlag = true;
	}

	void OnEnterCode()
	{
		
		if (runFlag)
		{
			AnimatorStateInfo info = cameraMove.GetCurrentAnimatorStateInfo(0);

			if (info.normalizedTime >= 1.0f)
			{
				UIManager.Instance.keyPadPanel.SetActive(true);
				Cursor.lockState = CursorLockMode.None;

				if (Input.GetMouseButton(1))
				{
					OutEnterCode();
				}
			}

		}
	}

	void OutEnterCode()
	{
		runFlag = false;
		cameraScript.GetComponent<PlayerLook>().enabled = true;
		playerScript.GetComponent<PlayerMove>().enabled = true;
		GameObject.Find("PlayerCamera").transform.Find("FocusCamera").GetComponent<ObserveObj>().enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		padNoticeText.text = "";
	}

	public void GameWinEnding()
	{
		if (gameOverFlag)
		{
			UIManager.Instance.keyPadPanel.SetActive(false);
			UIManager.Instance.gameOverPanel.SetActive(true);
			UIManager.Instance.gameOverPanel.transform.GetChild(1).gameObject.SetActive(true);
			UIManager.Instance.gameOverPanel.transform.GetChild(0).gameObject.SetActive(false);
		}

	}

	private void Update()
	{
		OnEnterCode();
		GameWinEnding();
	}

}
