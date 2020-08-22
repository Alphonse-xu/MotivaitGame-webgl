using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// load scene and main enter 
/// Do something before scene load
/// </summary>


public class LoadManager : MonoBehaviour
{
    private static LoadManager _instance;
    public GameObject loadScreen;
    public GameObject hideScreen;
    public Slider slider;
    public Text text;

    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled=false;
#endif

        _instance = this;
        DontDestroyOnLoad(_instance.gameObject);
    }
    public static LoadManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        loadScreen.SetActive(true);
        hideScreen.SetActive(false);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            slider.value = operation.progress;

            if (operation.progress >= 0.9F)
            {
                slider.value = 1;
                text.text = "press any key to continue";
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }


}
