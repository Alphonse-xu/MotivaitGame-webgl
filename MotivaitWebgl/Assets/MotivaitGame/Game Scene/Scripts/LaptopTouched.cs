using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopTouched : MonoBehaviour
{
    public Animator cameraMove;
    private InputField enterText;
    private Text noticeText;
    private GameObject cameraScript;
    private GameObject playerScript;
    private Transform enterPanel;

    private bool runFlag;
    public static bool internetFlag;

    private void Awake()
    {
        
        runFlag = false;
        playerScript = GameObject.Find("FPSPlayer");
        cameraScript = GameObject.Find("FPSPlayer/PlayerCamera");
        cameraMove = cameraScript.GetComponent<Animator>(); 
        enterPanel = GameObject.Find("UI").transform.Find("LaptopPanel");

        foreach (Transform tran in enterPanel.GetComponentsInChildren<Transform>(true))
        {
            if (tran.name == "InputField")
            {
                enterText = tran.gameObject.GetComponent<InputField>();
            }
            if (tran.name == "NoticeText")
            {
                noticeText = tran.gameObject.GetComponent<Text>();
            }
        }

        internetFlag = false;
    }

    void OnTouch()
    {
        cameraMove.Play("LaptopLook");
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
                         // Animation end or not
             if (info.normalizedTime >= 1.0f)
             {
                enterPanel.gameObject.SetActive(true);

                if (!internetFlag)
                {
                    noticeText.text = "Disconnect Internet";
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    enterText.ActivateInputField();
                    Canvas.ForceUpdateCanvases();

                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        if (enterText.text != "LATTE01")
                        {
                            noticeText.text = "Wrong Password";
                        }
                        else
                        {
                            enterText.gameObject.SetActive(false);
                            noticeText.text = "the first number they need has been scribbled on the Motivait leaflet on her desk.";
                        }
                    }

                    
                }

                if (Input.GetMouseButton(1))
                {
                        OutEnterCode();
                }
             }
                
        }
    }

    void OutEnterCode()
    {
        cameraScript.GetComponent<PlayerLook>().enabled = true;
        playerScript.GetComponent<PlayerMove>().enabled = true;
        runFlag = false;
        GameObject.Find("PlayerCamera").transform.Find("FocusCamera").GetComponent<ObserveObj>().enabled = true;
        enterPanel.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        noticeText.text = "";
    }

    private void Update()
    {
        OnEnterCode();
    }
}
