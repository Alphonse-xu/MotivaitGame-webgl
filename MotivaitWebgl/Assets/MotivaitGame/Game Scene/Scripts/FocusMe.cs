using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusMe : MonoBehaviour
{
    private ObserveObj focus;

    private GameObject useImage;
    private GameObject objImage;
    private GameObject useText;
    private GameObject cameraScript;
    private GameObject playerScript;

    private void Awake()
    {
        objImage = UIManager.Instance.gamePanel.transform.GetChild(0).gameObject;
        useImage = UIManager.Instance.gamePanel.transform.GetChild(3).GetChild(0).gameObject;
        useText = UIManager.Instance.gamePanel.transform.GetChild(3).GetChild(1).gameObject;
        playerScript = GameObject.Find("FPSPlayer");
        cameraScript = GameObject.Find("FPSPlayer/PlayerCamera");
        focus = cameraScript.transform.Find("FocusCamera").gameObject.GetComponent<ObserveObj>();
        gameObject.layer = LayerMask.NameToLayer("Touched");
    }

    void OnTouch()
    {
        useImage.SetActive(false);
        useText.SetActive(false);
        objImage.SetActive(true);
        cameraScript.GetComponent<PlayerLook>().enabled = false; // unable playerlook
        playerScript.GetComponent<PlayerMove>().enabled = false;//unable playermove

        ObserveObj.pivot = gameObject.transform;
        focus.SetFocused(gameObject);
    }

    void OutTouch()
    {
        focus.SetFocused(null);
        cameraScript.GetComponent<PlayerLook>().enabled = true; // unable playerlook
        playerScript.GetComponent<PlayerMove>().enabled = true;//unable playermove
    }
}
