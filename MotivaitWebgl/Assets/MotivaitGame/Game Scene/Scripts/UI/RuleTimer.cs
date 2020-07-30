using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleTimer : MonoBehaviour
{
    private Text clockText;
    private Text timeOutText;
    private float timer;
    private bool gameFlag;

    private void Awake()
    {
        timer = 5000f;
        gameFlag = true;
        timeOutText = UIManager.Instance.gameOverPanel.transform.GetChild(0).GetComponent<Text>();
        clockText = UIManager.Instance.gamePanel.transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFlag)
        {
            GameStart();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.Instance.settingPanelShow();
            }

            timer -= Time.deltaTime;
            clockText.text = "Time: " + (int)timer;
            TimeEnd();
        }
    }

    void GameStart()
    {
        Time.timeScale = 0;
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            gameFlag = false;
            UIManager.Instance.teachingPanel.SetActive(false);
        }
    }


    void TimeEnd()
    {
        if (timer <= 0)
        {
            timer = 5000f;
            Time.timeScale = 0;

            TimeOutPanelShow();

            if (Input.GetKeyDown(KeyCode.N))
            {
                UIManager.Instance.QuitGame();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Time.timeScale = 1;
                timeOutText.enabled = false;
            }
        }

    }

    void TimeOutPanelShow()
    {
        UIManager.Instance.gameOverPanel.SetActive(true);
        UIManager.Instance.gameOverPanel.transform.GetChild(1).gameObject.SetActive(false);
        timeOutText.text = "Time is over! Do you want try more? press any key to start with another 10min/n Press Y to start/n Press N to exit";
    }
}
