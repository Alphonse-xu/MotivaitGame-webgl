using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetManager : MonoBehaviour
{
    public GameObject setMenu;
    public GameObject startMenu;
    public GameObject optionsMenu;

    public void openSetting()
    {
        setMenu.SetActive(true);
        startMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void closeSetting()
    {
        setMenu.SetActive(false);
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        setMenu.SetActive(false);
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void HideOptionsMenu()
    {
        setMenu.SetActive(false);
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void openURL()
    {
        System.Diagnostics.Process.Start("https://www.motivait.net/");
    }
}
