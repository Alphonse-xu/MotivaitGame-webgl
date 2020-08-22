using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// uimanager 
/// </summary>


public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject settingPanel;
    public GameObject laptopPanel;
    public GameObject gamePanel;
    public GameObject teachingPanel;
    public GameObject keyPadPanel;
    public GameObject ObservePanel;

    public GameObject useIcon;
    public GameObject redKey;
    public GameObject bluekey;
    public GameObject screwdriver;
    public Text timeText;
    public Text lackText;
    public Text gameoverText;

    private float fadeSpeed = 1.5f;
    private bool fadeStarting = false;
    public RawImage rawImage;

    public GameObject cameraScript;
    public GameObject playerScript;
    public GameObject laptop;
    public InputField enterText;
    public Text noticeText;
    public Animator cameraMove;
    private bool laptopRunFlag;

    public Text padNoticeText;

    private void Awake()
    {
        cameraMove = cameraScript.GetComponent<Animator>();
        EventCenter.AddListener<int>(EventType.coutdown,TimerCountdown);
        EventCenter.AddListener<bool>(EventType.uitouchedobj, RayTouchedObj);
        EventCenter.AddListener<GameObject>(EventType.picktool, PickToolShow);
        EventCenter.AddListener<string>(EventType.lacktool, LackToolShow);
        EventCenter.AddListener(EventType.pausegame, SettingPanelShow);
        EventCenter.AddListener<bool>(EventType.teachingrule, TeachingPanelShow);
        EventCenter.AddListener<string>(EventType.gameover,GameOverPanelShow);
        EventCenter.AddListener<GameObject>(EventType.watchobj, WatchObjPanelShow);
        EventCenter.AddListener(EventType.outwatchobj, WatchObjPanelHide);
        EventCenter.AddListener(EventType.startgame, SceneFade);
        EventCenter.AddListener(EventType.laptopuse, LaptopUsed);
        EventCenter.AddListener<GameObject>(EventType.escapedoor, EscapeDoor);
    }

    private void Update()
    {
        if (fadeStarting)
        {
            StartFade();
        }

        if (laptopRunFlag)
        {
            OnEnterCode();
        }
    }

    private void EscapeDoor(GameObject gameObject)
    {
        keyPadPanel.SetActive(true);
        EnableScript(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitPress()
    {
        keyPadPanel.SetActive(false);
        EnableScript(true);
        Cursor.lockState = CursorLockMode.Locked;
        padNoticeText.text = "";
    }

    private void LaptopUsed()
    {
        cameraMove.Play("LaptopLook");
        EnableScript(false);
        laptop.layer = LayerMask.NameToLayer("Default");
        laptopRunFlag = true;
        Cursor.lockState = CursorLockMode.None;
        laptopPanel.gameObject.SetActive(true);
    }

    private void OnEnterCode()
    {
        AnimatorStateInfo info = cameraMove.GetCurrentAnimatorStateInfo(0);
        // Animation end or not
        if (info.normalizedTime >= 1.0f)
        {
            laptopPanel.gameObject.SetActive(true);
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

            if (Input.GetMouseButton(1))
            {
                OutEnterCode();
            }
        }
    }

    void OutEnterCode()
    {
        EnableScript(true);
        laptopRunFlag = false;
        Cursor.lockState = CursorLockMode.Locked;
        laptopPanel.gameObject.SetActive(false);
        noticeText.text = "";
    }

    private void SceneFade()
    {
        fadeStarting = true;
        rawImage.enabled = true;
    }

    void StartFade()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            fadeStarting = false;
        }
    }

    private void TimerCountdown(int time)
    {
        timeText.text = time.ToString();
    }

    private void RayTouchedObj(bool touched)
    {
        useIcon.SetActive(touched);
    }

    private void PickToolShow(GameObject gameObject)
    {
        if (gameObject.name == "RedKey")
        {
            redKey.SetActive(true);
        }
        else if (gameObject.name == "BlueKey")
        {
            bluekey.SetActive(true);
        }
        else
        {
            screwdriver.SetActive(true);
        }
    }

    private void SettingPanelShow()
    {
        settingPanel.SetActive(true);
    }

    private void TeachingPanelShow(bool iBoot)
    {
        teachingPanel.SetActive(iBoot);
    }

    private void LackToolShow(string s)
    {
        lackText.text = s;
        
    }

    private void GameOverPanelShow(string s)
    {
        keyPadPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameoverText.text = s;
    }

    private void WatchObjPanelShow(GameObject gameObject)
    {
        useIcon.SetActive(false);
        ObservePanel.SetActive(true);
    }

    private void WatchObjPanelHide()
    {
        ObservePanel.SetActive(false);
    }

    private void EnableScript(bool enable)
    {
        cameraScript.GetComponent<PlayerLook>().enabled = enable; // unable playerlook
        playerScript.GetComponent<PlayerMove>().enabled = enable;//unable playermove
    }

    public void QuitGame()
    {
    #if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
    #endif

    #if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    public void BackGame()
    {
        settingPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void openURL()
    {
        System.Diagnostics.Process.Start("https://www.motivait.net/");
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<int>(EventType.coutdown, TimerCountdown);
        EventCenter.RemoveListener<bool>(EventType.uitouchedobj, RayTouchedObj);
        EventCenter.RemoveListener<GameObject>(EventType.picktool, PickToolShow);
        EventCenter.RemoveListener<string>(EventType.lacktool, LackToolShow);
        EventCenter.RemoveListener(EventType.pausegame, SettingPanelShow);
        EventCenter.RemoveListener<bool>(EventType.teachingrule, TeachingPanelShow);
        EventCenter.RemoveListener<string>(EventType.gameover, GameOverPanelShow);
        EventCenter.RemoveListener<GameObject>(EventType.watchobj, WatchObjPanelShow);
        EventCenter.RemoveListener(EventType.outwatchobj, WatchObjPanelHide);
        EventCenter.RemoveListener(EventType.startgame, SceneFade);
        EventCenter.RemoveListener(EventType.laptopuse, LaptopUsed);
        EventCenter.RemoveListener<GameObject>(EventType.escapedoor, EscapeDoor);
    }
}
