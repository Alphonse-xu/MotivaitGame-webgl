using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInternet : MonoBehaviour
{
    private Text lackText;

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Touched");
        lackText = GameObject.Find("LackText").GetComponent<Text>();
    }

    void OnTouch()
    {
        LaptopTouched.internetFlag = true;
        lackText.text = "Wifi is opened";
    }
}
