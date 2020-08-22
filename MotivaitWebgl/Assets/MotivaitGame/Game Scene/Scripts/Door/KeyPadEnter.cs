using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// enter the password
/// </summary>

public class KeyPadEnter : MonoBehaviour
{
    private readonly string finalPassword = "7419";
    private string passwordTemp;

    public Text padNoticeText;


    public void Button0Press()
    {
        passwordTemp += "0";
    }

    public void Button1Press()
    {
        passwordTemp += "1";
    }
    public void Button2Press()
    {
        passwordTemp += "2";
    }
    public void Button3Press()
    {
        passwordTemp += "3";
    }
    public void Button4Press()
    {
        passwordTemp += "4";
    }
    public void Button5Press()
    {
        passwordTemp += "5";
    }
    public void Button6Press()
    {
        passwordTemp += "6";
    }
    public void Button7Press()
    {
        passwordTemp += "7";
    }
    public void Button8Press()
    {
        passwordTemp += "8";
    }
    public void Button9Press()
    {
        passwordTemp += "9";
    }
    public void ButtonMPress()
    {
        padNoticeText.text = "";
        if (passwordTemp == finalPassword)
        {
            EventCenter.Broadcast(EventType.passgame);
        }
        else
        {
            padNoticeText.text = "Wrong Password";
        }
    }
    public void ButtonCPress()
    {
        passwordTemp = "";
    }
}
