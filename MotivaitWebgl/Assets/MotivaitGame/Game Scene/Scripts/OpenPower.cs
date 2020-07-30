using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPower : MonoBehaviour
{
    private Text lackText;

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Touched");
        lackText = GameObject.Find("LackText").GetComponent<Text>();
    }

    void OnTouch()
    {
        Whiteboard.powerFlag = true;
        lackText.text = "Board is opened";
    }
}
