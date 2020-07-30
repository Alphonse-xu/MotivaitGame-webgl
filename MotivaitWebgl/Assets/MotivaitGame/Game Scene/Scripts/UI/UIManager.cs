using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject gameOverPanel;
    public GameObject settingPanel;
    public GameObject laptopPanel;
    public GameObject gamePanel;
    public GameObject teachingPanel;
    public GameObject keyPadPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameOverPanel = GameObject.Find("GameOverPanel");
        settingPanel = GameObject.Find("SettingPanel");
        laptopPanel = GameObject.Find("LaptopPanel");
        gamePanel = GameObject.Find("GamePanel");
        teachingPanel = GameObject.Find("TeachingPanel");
        keyPadPanel = GameObject.Find("KeyPadPanel");
    }

    private void Start()
    {
        gameOverPanel.transform.GetChild(0).gameObject.SetActive(false);
        gameOverPanel.transform.GetChild(1).gameObject.SetActive(false);
        settingPanel.SetActive(false);
        laptopPanel.SetActive(false);
        keyPadPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }


    public void settingPanelShow()
    {
        settingPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
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

    public void audioButtonShow()
    {
        //optionsMenu.SetActive(false);
        //audioButton.SetActive(true);
    }

    public void audioButtonHide()
    {
       // optionsMenu.SetActive(true);
        //audioButton.SetActive(false);
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

}
