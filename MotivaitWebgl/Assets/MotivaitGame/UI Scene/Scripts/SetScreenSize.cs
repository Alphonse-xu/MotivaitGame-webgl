using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenSize : MonoBehaviour
{
    private void Awake()
    {
        //Resolution[] resolutions = Screen.resolutions;
        //Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, false);
        Screen.SetResolution(1280, 720, false);
    }
   
}
